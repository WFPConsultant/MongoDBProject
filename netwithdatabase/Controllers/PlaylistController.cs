﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using netwithdatabase.Models;
using netwithdatabase.Services;

namespace netwithdatabase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaylistController : ControllerBase
    {
        private readonly MongoDBService _mongoDBService;

        public PlaylistController(MongoDBService mongoDBService)
        {
            _mongoDBService = mongoDBService;
        }



        [HttpGet]
        public async Task<List<Playlist>> Get()
        {
            return await _mongoDBService.GetAsync();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Playlist playlist)
        {
            await _mongoDBService.CreateAsync(playlist);
            return CreatedAtAction(nameof(Get), new { id = playlist.Id }, playlist);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AddToPlaylist(string id, [FromBody] string movieId)
        {
            await _mongoDBService.AddToPlaylistAsync(id, movieId);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _mongoDBService.DeleteAsync(id);
            return NoContent();
        }
    }
}
