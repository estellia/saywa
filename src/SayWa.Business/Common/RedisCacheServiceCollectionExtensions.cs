using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using StackExchange.Redis;
using System.IO;

namespace SayWa.Business
{
    public static class RedisCacheServiceCollectionExtensions
    {
        private static SocketManager socketManager;
        public static IServiceCollection AddMyRedisCache(this IServiceCollection services, IConfigurationRoot Configuration, string redisConfig = "")
        {
            if (string.IsNullOrWhiteSpace(redisConfig))
            {
                redisConfig = Configuration["Redis:ConnectionString"];
            }
            var muxer = Create(redisConfig);
            services.AddSingleton(typeof(IDatabase), muxer.GetDatabase());
            return services;
        }

        
        public static ConnectionMultiplexer Create(string configuration,
        string clientName = null, int? syncTimeout = null, bool? allowAdmin = null, int? keepAlive = null,
        int? connectTimeout = null, string password = null, string tieBreaker = null, TextWriter log = null,
        bool fail = true, string[] disabledCommands = null, string[] enabledCommands = null,
        bool checkConnect = true, bool pause = true, string failMessage = null,
        string channelPrefix = null, bool useSharedSocketManager = true, Proxy? proxy = null)
        {
            if (pause) System.Threading.Thread.Sleep(500); // get a lot of glitches when hammering new socket creations etc; pace it out a bit

            var config = ConfigurationOptions.Parse(configuration);
            if (disabledCommands != null && disabledCommands.Length != 0)
            {
                config.CommandMap = CommandMap.Create(new HashSet<string>(disabledCommands), false);
            }
            else if (enabledCommands != null && enabledCommands.Length != 0)
            {
                config.CommandMap = CommandMap.Create(new HashSet<string>(enabledCommands), true);
            }

            if (System.Diagnostics.Debugger.IsAttached)
            {
                syncTimeout = int.MaxValue;
            }

            if (useSharedSocketManager) config.SocketManager = socketManager;
            if (channelPrefix != null) config.ChannelPrefix = channelPrefix;
            if (tieBreaker != null) config.TieBreaker = tieBreaker;
            if (password != null) config.Password = string.IsNullOrEmpty(password) ? null : password;
            if (clientName != null) config.ClientName = clientName;
            if (syncTimeout != null) config.SyncTimeout = syncTimeout.Value;
            if (allowAdmin != null) config.AllowAdmin = allowAdmin.Value;
            if (keepAlive != null) config.KeepAlive = keepAlive.Value;
            if (connectTimeout != null) config.ConnectTimeout = connectTimeout.Value;
            if (proxy != null) config.Proxy = proxy.Value;

            var task = ConnectionMultiplexer.ConnectAsync(config, log ?? Console.Out);
            if (!task.Wait(config.ConnectTimeout >= (int.MaxValue / 2) ? int.MaxValue : config.ConnectTimeout * 2))
            {
                task.ContinueWith(x =>
                {
                    try
                    {
                        GC.KeepAlive(x.Exception);
                    }
                    catch
                    { }
                }, TaskContinuationOptions.OnlyOnFaulted);
                throw new TimeoutException("Connect timeout");
            }

            var muxer = task.Result;
            if (checkConnect)
            {
                if (!muxer.IsConnected)
                {
                    //if (fail) Assert.Fail(failMessage + "Server is not available");
                    //Assert.Inconclusive(failMessage + "Server is not available");
                }
            }
            //muxer.InternalError += OnInternalError;
            //muxer.ConnectionFailed += OnConnectionFailed;
            return muxer;
        }
    }
}
