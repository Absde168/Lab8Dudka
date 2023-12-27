public struct Knockout
{
    public DateTime StartTime;
    public string PuncherFullName;
    public string VictimFullName;
    public int RoundNumber;
    public TimeSpan EndTimeRelativeToRoundStart;
}

public class Program
{
    public static void Main(string[] args)
    {
        List<Knockout> knockouts = new List<Knockout>();

        // Добавляем данные о нокаутах
        knockouts.Add(new Knockout
        {
            StartTime = new DateTime(2021, 10, 10, 20, 30, 0),
            PuncherFullName = "Иванов Иван",
            VictimFullName = "Петров Петр",
            RoundNumber = 2,
            EndTimeRelativeToRoundStart = new TimeSpan(0, 2, 15)
        });

        knockouts.Add(new Knockout
        {
            StartTime = new DateTime(2021, 9, 15, 18, 45, 0),
            PuncherFullName = "Сидоров Алексей",
            VictimFullName = "Козлов Дмитрий",
            RoundNumber = 3,
            EndTimeRelativeToRoundStart = new TimeSpan(0, 1, 40)
        });

        // Выводим информацию о всех нокаутах
        Console.WriteLine("Информация о всех нокаутах:");
        foreach (Knockout knockout in knockouts)
        {
            TimeSpan roundDuration = new TimeSpan(0, 3, 0);
            TimeSpan breakDuration = new TimeSpan(0, 2, 0);
            TimeSpan totalDuration = roundDuration + breakDuration;

            DateTime endTime = knockout.StartTime + totalDuration * (knockout.RoundNumber - 1) + knockout.EndTimeRelativeToRoundStart;

            Console.WriteLine("Дата начала боя: " + knockout.StartTime.ToString("dd.MM.yyyy HH:mm:ss"));
            Console.WriteLine("Боксер, нанесший удар: " + knockout.PuncherFullName);
            Console.WriteLine("Боксер, потерпевший поражение: " + knockout.VictimFullName);
            Console.WriteLine("Номер раунда нокаута: " + knockout.RoundNumber);
            Console.WriteLine("Время окончания боя нокаутом: " + endTime.ToString("mm:ss"));
            Console.WriteLine();
        }

        // Выводим информацию о нокаутах за последние три месяца
        DateTime threeMonthsAgo = DateTime.Now.AddMonths(-3);

        Console.WriteLine("Информация о нокаутах за последние три месяца:");
        foreach (Knockout knockout in knockouts)
        {
            if (knockout.StartTime >= threeMonthsAgo)
            {
                TimeSpan roundDuration = new TimeSpan(0, 3, 0);
                TimeSpan breakDuration = new TimeSpan(0, 2, 0);
                TimeSpan totalDuration = roundDuration + breakDuration;

                DateTime endTime = knockout.StartTime + totalDuration * (knockout.RoundNumber - 1) + knockout.EndTimeRelativeToRoundStart;

                Console.WriteLine("Дата начала боя: " + knockout.StartTime.ToString("dd.MM.yyyy HH:mm:ss"));
                Console.WriteLine("Боксер, нанесший удар: " + knockout.PuncherFullName);
                Console.WriteLine("Боксер, потерпевший поражение: " + knockout.VictimFullName);
                Console.WriteLine("Номер раунда нокаута: " + knockout.RoundNumber);
                Console.WriteLine("Время окончания боя нокаутом: " + endTime.ToString("mm:ss"));
                Console.WriteLine();
            }
        }
    }
}