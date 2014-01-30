namespace GameLogic
{
	public class Player
	{
		//ctor

        public Player(string n)
        {
            name = n;

            _position = NetworkPosition.HOST;

            turn = 0;
        }

        public Player(string n, NetworkPosition np)
        {
            name = n;

            _position = np;

            turn = 0;
        }

		//public
		
			public string getName()
			{ return name; }
		
			public void setName(string n)
			{ name = n; }

            public void setNetPosition(NetworkPosition pos)
            { _position = pos; }

            public NetworkPosition getNetPosition()
            { return _position; }

            public void setTurn(int turnNum)
            { turn = turnNum; }

            public int getTurn()
            { return turn; }
		
		//private
		
		//private members
		//
		//	name
			private string name;
        
        //  network position
            private NetworkPosition _position;

        //  turn position : since this is going to change I think it is best we have a var for it, not sure what type, keeping it as 'int' for now
            private int turn;

		//  things ( this will have to have a bool (isOnRack)
		//
		//  characters ( for all non-special Characters this will also have to have a bool (isOnRacK)
		//
		// Rack ( this is an Obj, with just a list. mostly logic )
		// ( cannot keep gold counters, special characters, and forts )
	}

    // @ericadamski : we may be able to get ride of this I am not sure yet :p
    public enum NetworkPosition
    {
        HOST,
        CLIENT
    }
}