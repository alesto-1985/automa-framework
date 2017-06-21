namespace MessageSample.Messages
{
    class Task
    {

        public string Name { get; set; }
        public int Priority { get; set; }
        public string Context { get; set; }

        public override string ToString()
        {
            return string.Format("Name: {0}, Priority: {1}, Context: {2}", Name, Priority, Context);
        }

    }
}
