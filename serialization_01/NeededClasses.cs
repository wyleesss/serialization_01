namespace NeededClasses
{
    [Serializable]
    class Track
    {
        public ushort ID { get; }
        public List<Classes> Classes { get; set; }

        public Track(ushort ID)
        {
            this.ID = ID;
            Classes = new();
        }

        public Track(ushort ID, List<Classes> work)
        {
            this.ID = ID;
            Classes = work;
        }

        public override string ToString()
        {
            string res = $"[track]:\nID: {ID}\nclasses:\n";

            foreach (var c in Classes)
                res += c.ToString() + "\n";

            return res;
        }
    }

    [Serializable]
    class Classes
    {
        public DateTime Time { get; set; }
        public ushort TrackID { get; set; }
        public string TrainerName { get; set; }
        public ushort GroupID { get; set; }

        public Classes(DateTime time, ushort trackID, string trainerName, ushort groupID)
        {
            Time = time;
            TrackID = trackID;
            TrainerName = trainerName;
            GroupID = groupID;
        }

        public override string ToString()
        {
            return $"[classes]:\ntime: {Time}\ntrack ID: {TrackID}\ntrainer name: {TrainerName}\ngroup ID: {GroupID}\n";
        }
    }

    [Serializable]
    class Trainer
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public uint HourSalary { get; set; }
        public List<Classes> Classes { get; set; }

        public string FullName => $"{Name} {Surname}";

        public Trainer(string name, string surname, string phoneNumber, uint hourSalary)
        {
            Name = name;
            Surname = surname;
            PhoneNumber = phoneNumber;
            HourSalary = hourSalary;
            Classes = new();
        }

        public Trainer(string name, string surname, string phoneNumber, uint hourSalary, List<Classes> classes)
        {
            Name = name;
            Surname = surname;
            PhoneNumber = phoneNumber;
            HourSalary = hourSalary;
            Classes = classes;
        }

        public override string ToString()
        {
            string res = $"[trainer]:\nfull name: {FullName}\nphone number: {PhoneNumber}\nhour salary: {HourSalary}\nclasses:\n";

            foreach (var c in Classes)
                res += c.ToString() + "\n";

            return res;
        }
    }

    [Serializable]
    class Group
    {
        public ushort ID { get; }
        public List<Student> Students { get; set; }

        public Group(ushort iD)
        {
            ID = iD;
            Students = new();
        }

        public Group(ushort iD, List<Student> students)
        {
            ID = iD;
            Students = students;
        }

        public override string ToString()
        {
            string res = $"[group]:\nID: {ID}\nstudents:\n";

            foreach (var s in Students)
                res += s.ToString() + "\n";

            return res;
        }
    }

    [Serializable]
    class Student
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string ParentName { get; set; }
        public string PhoneNumber { get; set; }
        public ushort PayedClasses { get; set; }
        public ushort GroupID { get; set; }

        public string FullName => $"{Name} {Surname}";

        public Student(string name, string surname, string parentName, string phoneNumber, ushort payedClasses, ushort groupID)
        {
            Name = name;
            Surname = surname;
            ParentName = parentName;
            PhoneNumber = phoneNumber;
            PayedClasses = payedClasses;
            GroupID = groupID;
        }

        public override string ToString()
        {
            return $"[student]:\nfull name: {FullName}\nparent name: {ParentName}\nphone number: {PhoneNumber}\npayed classes: {PayedClasses}\ngroup ID: {GroupID}\n";
        }
    }
}