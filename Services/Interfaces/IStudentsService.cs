using Academy.Models.Domain;
using Academy.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Services.Interfaces
{
    public interface IStudentsService
    {
        int Insert(StudentAddRequest model);
        List<Students> SelectAll();
        Students SelectById(int id);
        void Update(StudentUpdateRequest model);
        void Delete(int id);
    }
}
