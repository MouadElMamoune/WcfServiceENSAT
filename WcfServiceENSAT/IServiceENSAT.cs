using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServiceENSAT
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom d'interface "IServiceENSAT" à la fois dans le code et le fichier de configuration.
    [ServiceContract]
    public interface IServiceENSAT
    {
        [OperationContract]
        Student getStudent(int id);

        [OperationContract]
        void addStudent(Student s);

        [OperationContract]
        void deleteStudent(int id);

        [OperationContract]
        void updateStudent(Student s);

        [OperationContract]
        List<Student> getAllStudents();
    }
}
