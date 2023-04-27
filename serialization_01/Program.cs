using System.Runtime.Serialization.Formatters.Binary;

using NeededClasses;

#pragma warning disable SYSLIB0011 // <-- вимикаємо помилку "SYSLIB0011" пов'язану з "BinaryFormatter.Serialize()"

class Program
{
    static void Main()
    {
        Trainer trainer = new("Jack", "Greenlish", "+1023478654", 100);
        Trainer? DeserializedTrainerObj = null;

        Track track = new(11);
        Track? DeserializedTrackObj = null;

        Group group = new(127);
        Group? DeserializedGroupObj = null;

        Classes classes = new(DateTime.Now, track.ID, trainer.FullName, group.ID);
        Student student = new("Alex", "Lovare", "Sabina Lovare", "+1023343411", 30, group.ID);

        group.Students.Add(student);
        track.Classes.Add(classes);
        trainer.Classes.Add(classes);

        BinaryFormatter binFormatter = new();

        try
        {
            using (Stream fStream = File.Create("trainer.bin"))
                binFormatter.Serialize(fStream, trainer);

            using (Stream fStream = File.Create("track.bin"))
                binFormatter.Serialize(fStream, track);

            using (Stream fStream = File.Create("group.bin"))
                binFormatter.Serialize(fStream, group);


            using (Stream fStream = File.OpenRead("trainer.bin"))
                DeserializedTrainerObj = (Trainer)binFormatter.Deserialize(fStream);

            using (Stream fStream = File.OpenRead("track.bin"))
                DeserializedTrackObj = (Track)binFormatter.Deserialize(fStream);

            using (Stream fStream = File.OpenRead("group.bin"))
                DeserializedGroupObj = (Group)binFormatter.Deserialize(fStream);

            Console.WriteLine("--ORIGINAL:--\n");
            Console.WriteLine(trainer);
            Console.WriteLine(group);
            Console.WriteLine(track);

            Console.WriteLine("\n--DESERIALIZED:--\n");
            Console.WriteLine(DeserializedTrainerObj);
            Console.WriteLine(DeserializedGroupObj);
            Console.WriteLine(DeserializedTrackObj);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}