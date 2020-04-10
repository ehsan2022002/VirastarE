namespace BrozoyaEntitys
{
    public class T_DocTree
    {
        public T_DocTree()
        { }

        public T_DocTree(int ID)
        {
            this.Id = ID;           
        }

        public int Id { set; get; }
        public int? PId { set; get; }
        public string NodeTitle { set; get; }
        public int NodeType { set; get; }

    }
}
