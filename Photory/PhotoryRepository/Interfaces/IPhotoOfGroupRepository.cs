using PhotoryModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoryRepository.Interfaces
{
    public interface IPhotoOfGroupRepository :IRepository<PhotoOfGroup>
    {
        Photo GetOnePhoto(string id);
    }
}
