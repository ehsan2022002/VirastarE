//Copyright (C) 2006 Richard J. Northedge
//
// This library is free software; you can redistribute it and/or
// modify it under the terms of the GNU Lesser General Public
// License as published by the Free Software Foundation; either
// version 2.1 of the License, or (at your option) any later version.
//
// This library is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU Lesser General Public License for more details.
//
// You should have received a copy of the GNU Lesser General Public
// License along with this program; if not, write to the Free Software
// Foundation, Inc., 59 Temple Place - Suite 330, Boston, MA  02111-1307, USA.

namespace SharpWordNet
{
    /// <summary>
    /// Summary description for RelationType.
    /// </summary>
    public class RelationType
    {
        private string mName;
        private RelationType mOpposite;
        private string[] mPartsOfSpeech;

        public string Name
        {
            get
            {
                return mName;
            }
        }

        public RelationType Opposite
        {
            get
            {
                return mOpposite;
            }
        }

        public string GetPartOfSpeech(int index)
        {
            return mPartsOfSpeech[index];
        }

        public int PartsOfSpeechCount
        {
            get
            {
                return mPartsOfSpeech.Length;
            }
        }

        protected internal RelationType(string name, string[] partsOfSpeech)
        {
            mName = name;
            mPartsOfSpeech = partsOfSpeech;
        }

        protected internal RelationType(string name, RelationType opposite, string[] partsOfSpeech)
        {
            mName = name;
            mOpposite = opposite;
            mPartsOfSpeech = partsOfSpeech;
        }
    }
}
