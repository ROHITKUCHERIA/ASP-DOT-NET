using ModelToController.Models;

namespace ModelToController.Repository
{
    public class StudentRepository : IStudent
    {
        public List<StudentModel> getAllStudents()
        {
            return DataSource();
        }

        public StudentModel getStudentById(int id)
        {
            return DataSource().FirstOrDefault(x => x.RollNo == id);
        }


        private List<StudentModel> DataSource()
        {
            return new List<StudentModel>
            {
                new StudentModel {RollNo = 1,Name = "Rohit Kucheria", Gender = "Male",Standard = 11},
                new StudentModel {RollNo = 2,Name = "Manish Kucheria", Gender = "Male",Standard = 12},
                new StudentModel {RollNo = 3,Name = "Rajesh", Gender = "Male",Standard = 10},
                new StudentModel {RollNo = 3,Name = "Eve", Gender = "Female",Standard = 9}
            };
        }
    }
}
