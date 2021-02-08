using AutoMapper;
using MusicLibrary.Business.Models.Album;
using MusicLibrary.Business.Services.Interfaces;
using MusicLibrary.DAL.Entities;
using MusicLibrary.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MusicLibrary.Business.Services
{
    public class AlbumService : IAlbumService
    {
        private readonly IAlbumRepository _albumRepository;
        private readonly IMapper _mapper;

        public AlbumService(IAlbumRepository albumRepository, IMapper mapper)
        {
            _albumRepository = albumRepository;
            _mapper = mapper;
        }

        public List<AlbumModel> GetAll(Expression<Func<AlbumModel, bool>> filter = null)
        {
            var repoFilter = _mapper.Map<Expression<Func<Album, bool>>>(filter);

            var result = _albumRepository.GetAll(repoFilter);

            return _mapper.Map<List<AlbumModel>>(result);
        }

        public AlbumModel GetById(Guid id)
        {
            var result = _albumRepository.GetById(id);

            return _mapper.Map<AlbumModel>(result);
        }

        public async Task InsertAsync(CreateAlbumModel model)
        {
            var entity = _mapper.Map<Album>(model);

            await _albumRepository.InsertAndSaveAsync(entity);
        }

        public async Task UpdateAsync(AlbumModel model)
        {
            var entity = _mapper.Map<Album>(model);

            await _albumRepository.UpdateAndSaveAsync(entity);
        }

        public async Task RemoveAsync(Guid id)
        {
            await _albumRepository.DeleteAndSaveAsync(id);
        }
    }
}