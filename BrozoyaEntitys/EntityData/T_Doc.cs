namespace BrozoyaEntitys
{
    public class T_Doc
    {
        public T_Doc()
        { }

        public T_Doc(int ID)
        {
            this.Id = ID;
        }
        
        public T_Doc(int ID, float Score)
        {
            this.Id = ID;
            this.score = Score;
        }

        public int Id { set; get; }
        public string DocTitle { set; get; }
        public string Doc { set; get; }
        public string CreateDate { set; get; }
        public string InsetDate { set; get; }
        public string UserID { set; get; }
        public string Address { set; get; }
        public string Keywords { set; get; }
        public int DOCTREE_ID { set; get; }
        public float score { set; get; }        
        public string FullDoc { set; get; }
        public byte[] blobDoc { set; get; }
        
    }
}
