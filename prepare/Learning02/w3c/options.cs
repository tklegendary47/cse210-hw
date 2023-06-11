public class Options
    {
        public string _introduction;
        public string _first;
        public string _second;
        public string _third;
        public string _fourth;
        public string _fifth;
        
        public void Display()
        {
            Console.WriteLine($"{_introduction}");
            Console.WriteLine($"1.{_first}");
            Console.WriteLine($"2.{_second}");
            Console.WriteLine($"3.{_third}");
            Console.WriteLine($"4.{_fourth}");
            Console.WriteLine($"5.{_fifth}");    
        }

     }