using APP_BUS_L_10.DTO.Depatments;
using APP_BUS_L_10.Factories.Departments;
using APP_DATA_A_10.Models;
using APP_DATA_A_10.Repositories.Depatment;
using APP_DATA_A_10.Repositories.UOW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP_BUS_L_10.Services.Departments
{
    public class DepartmentServices : IDepartmentServices
    {
       
        private readonly IUnitOfWork _ofWork;
        public DepartmentServices(IUnitOfWork ofWork)
        {
            _ofWork = ofWork;
        }

        public IEnumerable<DepartmentDto> GetDepartments()
        {
            var allDep = _ofWork.DepartmentRepository.getAll();
            var depatDto = allDep.Select((d) => d.toDepartmentDto());
            return depatDto;

        }


        public DepartmentDetelesDto getDepatId(int id)
        {
            var depatId = _ofWork.DepartmentRepository.getDepatId(id);
            if (depatId != null)
            {
                return depatId.toDepartmentDeteles();
            }
            else
            {
                return null;
            }
        }

        public int addDepart(AddDepartmentDbo add)
        {
          _ofWork.DepartmentRepository.Add(add.toEntity());
            //return addDepart;
            return _ofWork.SaveChanges();

        }

        public int updateDepart(UpdateDepartment update)
        {
          _ofWork.DepartmentRepository.Update(update.toEntity());
            //return updateDep;
            return _ofWork.SaveChanges();

        }

        public bool deleteDepart(int id)
        {
            var departId = _ofWork.DepartmentRepository.getDepatId(id);

            if (departId != null)
            {
                _ofWork.DepartmentRepository.Remove(departId);
                var result = _ofWork.SaveChanges();  // ← هنا الحفظ الفعلي
                return result > 0;
            }

            return false;

        }

    }
}
