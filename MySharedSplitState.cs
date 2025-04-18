using Splitio.Services.Client.Classes;
using Splitio.Services.Client.Interfaces;
using Splitio.Domain;

public class MySharedSplitState
{
    private static ISplitClient _sdk;

    static MySharedSplitState()
    {
        var cacheAdapterConfigurationOptions = new CacheAdapterConfigurationOptions
        {
            Type = AdapterType.Redis,
            Host = "localhost",
            Port = "6379",
            Password = "",
            Database = 0,
            ConnectTimeout = 5000,
            ConnectRetry = 3,
            SyncTimeout = 1000,
            UserPrefix = "DBM",
            PoolSize = 1
        };

        var config = new ConfigurationOptions
        {
            Mode = Mode.Consumer,
            CacheAdapterConfig = cacheAdapterConfigurationOptions
        };

        var factory = new SplitFactory("28bddhnjht06lvi8e5aa9rkmv5glsc40ltaa", config);
        _sdk = factory.Client();
    }

    public static void Initialize()
    {
        _sdk.BlockUntilReady(5000); // optional wait for readiness
    }

    public static ISplitClient Client => _sdk;
}
