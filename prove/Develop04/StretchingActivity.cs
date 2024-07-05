using System;
using System.Collections.Generic;

public class StretchingActivity : Activity
{
    private List<string> _stretches;
    private List<string> _usedStretches;

    public StretchingActivity() : base("Stretching", "This activity will help you relax by guiding you through a series of gentle stretches. Follow the instructions and focus on your breathing as you stretch.")
    {
        _stretches = new List<string>
        {
            "Neck Stretch: Tilt your head to the left, bringing your ear toward your shoulder. Hold for 10 seconds, then switch sides.",
            "Shoulder Stretch: Raise your right arm and reach over to your left, pulling gently with your left hand. Hold for 10 seconds, then switch sides.",
            "Triceps Stretch: Raise your right arm and bend it behind your head. Use your left hand to gently push your elbow down. Hold for 10 seconds, then switch sides.",
            "Hamstring Stretch: Sit on the floor with one leg extended and the other bent. Reach toward your extended foot. Hold for 10 seconds, then switch legs.",
            "Quadriceps Stretch: Stand on one leg and pull your other foot up towards your buttocks. Hold for 10 seconds, then switch legs.",
            "Calf Stretch: Stand with your hands against a wall. Step one foot back and press your heel into the ground. Hold for 10 seconds, then switch legs."
        };
        _usedStretches = new List<string>();
    }

    public override void Run()
    {
        DisplayStartingMessage();

        int elapsed = 0;
        int stretchDuration = 10;
        Random random = new Random();

        while (elapsed < _duration)
        {
            if (_usedStretches.Count == _stretches.Count)
            {
                _usedStretches.Clear();
            }

            string stretch = GetRandomStretch(random);

            Console.WriteLine("\n" + stretch);
            ShowCountDown(stretchDuration);
            elapsed += stretchDuration + 5; // Add extra time for switching stretches
        }

        DisplayEndingMessage();
    }

    private string GetRandomStretch(Random random)
    {
        string stretch;
        do
        {
            stretch = _stretches[random.Next(_stretches.Count)];
        } while (_usedStretches.Contains(stretch));

        _usedStretches.Add(stretch);
        return stretch;
    }
}
