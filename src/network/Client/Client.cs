using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KNT_Client
{
    public interface Client
    {
        void open();
        void close();
        void joinGame();
        void update();

    }
}
