namespace ObjReader
{
    interface ILineProcessor
    {
        public string Keyword { get; }

        void Execute(string line);
    }
}
