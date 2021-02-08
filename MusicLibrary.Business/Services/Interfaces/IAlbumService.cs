using MusicLibrary.Business.Models.Album;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MusicLibrary.Business.Services.Interfaces
{
    public interface IAlbumService
    {
        List<AlbumModel> GetAll(Expression<Func<AlbumModel, bool>> filter = null);
        AlbumModel GetById(Guid id);
        Task InsertAsync(CreateAlbumModel model);
        Task RemoveAsync(Guid id);
        Task UpdateAsync(AlbumModel model);
    }
}