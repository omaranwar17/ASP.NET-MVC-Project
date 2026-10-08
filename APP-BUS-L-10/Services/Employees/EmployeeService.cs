using APP_BUS_L_10.Services.Attachment;
using APP_DATA_A_10.Models.Employees;
using APP_DATA_A_10.Repositories.Employees;
using APP_DATA_A_10.Repositories.UOW;
using APP_DATA_A_10.Services.Employees.Dtos;
using APP_DATA_A_10.Services.Employees.Factories;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace APP_DATA_A_10.Services.Employees
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEmployeeFactory _employeeFactory;
        private readonly IMapper _mapper1;
        private readonly IAttachmentService _attachmentService1;

        public EmployeeService(
            IUnitOfWork unitOfWork,
            IEmployeeFactory employeeFactory , IMapper mapper,
            IAttachmentService attachmentService)
        {
            _unitOfWork = unitOfWork;
            _employeeFactory = employeeFactory;
            _mapper1 = mapper;
            _attachmentService1 = attachmentService;

        }

        // ============ Get All ============

      
        public IEnumerable<EmployeeDto> GetAll(string? EmployeeSearchName)
        {
            IEnumerable<Employee> employees;
            // نشيل المسافات من الأول والآخر
            EmployeeSearchName = EmployeeSearchName?.Trim();

            //var employees = _employeeRepository.getAll();
            if (string.IsNullOrWhiteSpace(EmployeeSearchName))
            {
                employees = _unitOfWork.EmployeeRepositry.getAll();
               
                //return _employeeFactory.ToDtoList(employees);
            
            }
            else
            {
                 employees = _unitOfWork.EmployeeRepositry.getAll(e => e.Name.ToLower().Contains(EmployeeSearchName.ToLower()));
               
            }

           

            //return _employeeFactory.ToDtoList(employees);
            var eplR = _mapper1.Map<IEnumerable<Employee>, IEnumerable<EmployeeDto>>(employees);
            return eplR;

        }


        // ============ Get By Id ============
        public EmployeeDetailsDto? GetById(int id)
        {
            var employee = _unitOfWork.EmployeeRepositry.getDepatId(id);
            if (employee is null) return null;

            return _employeeFactory.ToDetailsDto(employee);
        }


        // ============ Add ============
        public int Add(CreateEmployeeDto dto)
        {
            var employee = _mapper1.Map<Employee>(dto);

            //var employee = _employeeFactory.ToEntity(dto);
            if (employee != null)
            {
                employee.Image = _attachmentService1.Upload(dto.Image, "Images");
            }
             _unitOfWork.EmployeeRepositry.Add(employee);
            return _unitOfWork.SaveChanges();
        }

        // ============ Update ============
        public int Update(UpdateEmployeeDto dto)
        {
            var employee = _unitOfWork.EmployeeRepositry.getDepatId(dto.Id);
            if (employee is null)
            {
                return 0;
            }



            _employeeFactory.UpdateEntity(employee, dto);
            return _unitOfWork.SaveChanges();
        }

        // ============ Delete ============
        public int Delete(int id)
        {
            var employee = _unitOfWork.EmployeeRepositry.getDepatId(id);
            if (employee is null) return 0;
            employee.IsDeleted = true;
            return _unitOfWork.SaveChanges();
            {
                return 1;
            }
            return 0;

            //return _employeeRepository.Remove(employee);
        }
    }
}