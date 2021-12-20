using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServiceENSAT
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "ServiceENSAT" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez ServiceENSAT.svc ou ServiceENSAT.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public class ServiceENSAT : IServiceENSAT
    {
        DataClassesENSATDataContext d = new DataClassesENSATDataContext();
        public Student getStudent(int id)
        {
            return (from p in d.Student where p.ID == id select p).FirstOrDefault();
        }

        public void addStudent(Student s)
        {
            d.Student.InsertOnSubmit(s);
            d.SubmitChanges();
        }

        public void deleteStudent(int id)
        {
            d.Student.DeleteOnSubmit(this.getStudent(id));
            d.SubmitChanges();
        }

        public void updateStudent(Student s)
        {
            Student stud = new Student();
            stud.ID = s.ID ;
            stud.FNAME = s.FNAME;
            stud.LNAME = s.LNAME;
            stud.MAIL = s.MAIL;
            stud.PHONE = s.PHONE;
            d.Student.DeleteOnSubmit(this.getStudent(s.ID));
            d.Student.InsertOnSubmit(stud);
            d.SubmitChanges();
        }

        public List<Student> getAllStudents()
        {
            return d.Student.ToList();
        }
    }
}
