using System;

namespace EventPlanning
{
    public abstract class Event
    {
        private string _title;
        private string _description;
        private DateTime _date;
        private string _time;
        private Address _address;

        protected Event(string title, string description, DateTime date, string time, Address address)
        {
            _title = title;
            _description = description;
            _date = date;
            _time = time;
            _address = address;
        }

        public virtual string GetStandardDetails()
        {
            return $"Title: {_title}\nDescription: {_description}\nDate: {_date.ToShortDateString()}\nTime: {_time}\nAddress: {_address}";
        }

        public abstract string GetFullDetails();

        public string GetShortDescription()
        {
            return $"{GetType().Name}: {_title} on {_date.ToShortDateString()}";
        }
    }
}
