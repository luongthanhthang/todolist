using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace WorkDo1.Data;

public class ConnectMongoDB<T>
{
  private MongoClient _mongoClient = null;
  private IMongoDatabase _database = null;
  private IMongoCollection<T> _workOfDayTable = null;
  public IMongoCollection<T> Connect(string databaseName, string collectionName) {
    var settings = MongoClientSettings.FromConnectionString("mongodb+srv://thanhthang123456:thanhthang123456@cluster0.1ubayq8.mongodb.net/?retryWrites=true&w=majority");
    settings.ServerApi = new ServerApi(ServerApiVersion.V1);

    _mongoClient = new MongoClient(settings);
    _database = _mongoClient.GetDatabase(databaseName);
    return _database.GetCollection<T>(collectionName);
  }
}
