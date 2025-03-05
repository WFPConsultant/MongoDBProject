using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using netwithdatabase.Models;

namespace netwithdatabase.Services
{
    public class MongoDBService
    {
        private readonly IMongoCollection<Playlist> _playlistCollection;
        private readonly IMongoCollection<Movielist> _movielistCollection;

        private readonly IMemoryCache _memoryCache;
        public string cacheKey = "movies";
        public MongoDBService(IOptions<MongoDBSettings> mongoDBSettings, IMemoryCache memoryCache) //IMemoryCache memoryCache
        {
            MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
            IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
            _playlistCollection = database.GetCollection<Playlist>(mongoDBSettings.Value.CollectionName);

            //movies
            _movielistCollection = database.GetCollection<Movielist>(mongoDBSettings.Value.CollectionNameMovie);

            //
            _memoryCache = memoryCache;
        }

        //get movies
        public async Task<List<Movielist>> GetMovieAsync()
        {
            List<Movielist> movielist;
            if (!_memoryCache.TryGetValue(cacheKey, out movielist))
            {
                movielist =await _movielistCollection.Find(new BsonDocument()).Limit(10).ToListAsync();//GetValuesFromDbAsync().Result;

                _memoryCache.Set(cacheKey, movielist,
                   new MemoryCacheEntryOptions()
                   .SetAbsoluteExpiration(TimeSpan.FromSeconds(5)));
            }
            return movielist;
            //return await _movielistCollection.Find(new BsonDocument()).Limit(3).ToListAsync();
        }
        public async Task<List<Playlist>> GetAsync()
        {
            return await _playlistCollection.Find(new BsonDocument()).ToListAsync();
        }
        public async Task CreateAsync(Playlist playlist) 
        {
            await _playlistCollection.InsertOneAsync(playlist);
            return;
        }
        public async Task AddToPlaylistAsync(string id, string movieId)
        {
            FilterDefinition<Playlist> filter = Builders<Playlist>.Filter.Eq("Id", id);
            UpdateDefinition<Playlist> update = Builders<Playlist>.Update.AddToSet<string>("movieIds", movieId);
            await _playlistCollection.UpdateOneAsync(filter, update);
            return;
        }
        public async Task DeleteAsync(string id)
        {
            FilterDefinition<Playlist> filter = Builders<Playlist>.Filter.Eq("Id", id);
            await _playlistCollection.DeleteOneAsync(filter);
            return;
        }
    }
}
