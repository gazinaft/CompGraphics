namespace ObjReader
{
    class CommentLineProcessor : ILineProcessor
    {
        public string Keyword => "#";

        public void Execute(string line)
        {
            //Ignore
            return;
        }
    }
}
