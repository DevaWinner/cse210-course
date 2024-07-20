using System;

namespace EventPlanning
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create addresses
            Address address1 = new Address("342 Adam St", "Springfield", "IL", "62701");
            Address address2 = new Address("456 Elm St", "Shelbyville", "UT", "62702");
            Address address3 = new Address("789 Oak St", "Capital City", "IL", "62703");

            // Create events
            Lecture lecture = new Lecture("Tech Talk", "A talk on the latest in tech.", new DateTime(2024, 8, 1), "10:00 AM", address1, "Dr. Smith", 100);
            Reception reception = new Reception("Networking Event", "An event to network with professionals.", new DateTime(2024, 8, 2), "6:00 PM", address2, "rsvp@example.com");
            OutdoorGathering outdoorGathering = new OutdoorGathering("Community Picnic", "A picnic for the community.", new DateTime(2024, 8, 3), "12:00 PM", address3, "Sunny with a chance of rain");

            // Display marketing messages
            Console.Clear();
            Console.WriteLine("Event Details: \n");
            Event[] events = { lecture, reception, outdoorGathering };

            foreach (Event evt in events)
            {
                Console.WriteLine(evt.GetStandardDetails());
                Console.WriteLine();
                Console.WriteLine(evt.GetFullDetails());
                Console.WriteLine();
                Console.WriteLine(evt.GetShortDescription());
                Console.WriteLine();
            }
        }
    }
}
