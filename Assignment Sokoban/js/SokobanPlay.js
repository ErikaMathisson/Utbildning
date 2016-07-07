(function() {
	"use strict"; 
	document.onreadystatechange = function() {

			if(document.readyState === "complete") {

			//building the new sokobanBoard
			var sokobanBoard = buildSokobanBoard();
			//position for the character
			var characterPosition = {x: 0, y : 0};
			printSokoban();
		}
		//function for building the sokobanboard and add the different tiles and enteties
		function buildSokobanBoard()
		{
			//height and width of the map
			var height = tileMap01.height;
			var width = tileMap01.width;
			var board = new Array(height);
						
			//create a new multidimensional array for storing the tiles and enteties
			for(var i = 0; i < board.length; i++)
			{
				board[i] = new Array(width);			
			}
			
			//nested for-loop for looping through the mapGrid and setting the tiles and enteties to the new array board
			for(var i = 0; i < board.length; i++)
			{
				for(var j = 0; j < board[i].length; j++)
				{
					var cell = {Tiles: null, Entities: null};
					var sokobanCell = tileMap01.mapGrid[i][j];
					
					if(sokobanCell == ' ')
					{
						cell.Tiles = Tiles.Space;
					}
					else if(sokobanCell == 'W')
					{
						cell.Tiles = Tiles.Wall;
					}
					else if(sokobanCell == 'G')
					{
						cell.Tiles = Tiles.Goal;
					}
					else if(sokobanCell == 'B')
					{
						cell.Tiles = Tiles.Space;
						cell.Entities = Entities.Block;		
					}
					else if(sokobanCell == 'P')
					{
						cell.Tiles = Tiles.Space;
						cell.Entities = Entities.Character;
						//setting the position for the character
						characterPosition = {x:i,y:j};
						characterPosition.x = i;
						characterPosition.y = j;
					}
					// add the cellinformation to the board
					board[i][j] = cell;			
				}		
			}
			return board;	
		};

		//print the sokobanboard
		function printSokoban()
		{
			//for adding the board on the html-page, in a table
			var soko = document.getElementById("soko");
			//output for the html-page
			var output = "";
			//how many blocks are still not in the goal, that is hasn't been converted to blockdone
			var nrOfBlock = 0;
			//for printing that all blocks are in the goal
			var winner = document.getElementById("winner");
			//nested for-loop for printing the board
			for(var i = 0; i <sokobanBoard.length; i++)
			{	//start row in the table
				output += "<tr>";
				for(var j = 0; j < sokobanBoard[i].length; j++)
				{
					var cell = sokobanBoard[i][j];
					var blockStyle;
					//adding the style of the blocks in the sokobanboard						
					if(cell.Entities == Entities.Block)
					{	
						blockStyle ="block space";
						// how many blocks are still in the game
						nrOfBlock ++;
					}
					else if(cell.Entities == Entities.BlockDone)
					{
						blockStyle ="blockDone space";	
					}			
					else if(cell.Entities == Entities.Character)
					{
						blockStyle ="character space";
						//add the position of the character
						characterPosition = {x:i,y:j};
					}
					else if(cell.Tiles == Tiles.Space)
					{
						blockStyle ="space";				
					}
					else if(cell.Tiles == Tiles.Wall)
					{
						blockStyle ="wall";	
					}
					else if(cell.Tiles == Tiles.Goal)
					{
						blockStyle ="goal";	
					}
					//add the table data element to the html output		
					output += "<td class='blockSize "+ blockStyle + "'>";	
					output += "</td>";					
				}
				//end tag for the table row for the output	
				output += "</tr>";
				//add the layout for the html page
				soko.innerHTML = output;			
			}
			// number of blocks is zero, that is all blocks are in the goal-area, print info to user
			if(nrOfBlock === 0)
			{
				winner.innerHTML = "Congratulations!!!!!";				
			}	
			//event for what key the user pressed
			document.onkeyup = getPressedKey;	
		};

		//Function for getting what key the user pressed and what way the character wants to move
		function getPressedKey(e)
		{
			switch (e.keyCode) {
				case 37:
					move(0, -1);
					break;
				case 38:
					move(-1, 0);			
					break;
				case 39:
					move(0, 1);
					break;
				case 40:
					move(1, 0);
					break;
				default:
					alert("Not a valid key, only up, down, left and right key is valid, try again");
					break;
			}
		};

		//function for moving the character
		function move(xM, yM)
		{
			//variables for where the user wants to move
			var tempX = characterPosition.x + xM;
			var tempY = characterPosition.y + yM;
			//is the player able to move? That is no walls in the way		
			if(sokobanBoard[tempX][tempY].Tiles !== Tiles.Wall)
			{	//the player can be moved
				var movePlayer = true;
				//check if there are any blocks in way that is if they should be moved
				if(sokobanBoard[tempX][tempY].Entities == Entities.Block || sokobanBoard[tempX][tempY].Entities == Entities.BlockDone)
				{
					//the block or blockDone can be moved, there are no walls, blocks or blockdones in the way
					if(sokobanBoard[tempX + xM][tempY + yM].Tiles != Tiles.Wall &&
					sokobanBoard[tempX + xM][tempY + yM].Entities != Entities.Block &&
					sokobanBoard[tempX + xM][tempY + yM].Entities != Entities.BlockDone)
					{
						//move the block
						sokobanBoard[tempX + xM][tempY + yM].Entities = Entities.Block;
						//remove the block from it's original position
						sokobanBoard[tempX][tempY].Entities = null;
						//the block has reached the goal and the block is converted to a blockdone							
						if(sokobanBoard[tempX + xM][tempY + yM].Tiles == Tiles.Goal)				
						{
							sokobanBoard[tempX + xM][tempY + yM].Entities = Entities.BlockDone;						
						}						
					}
					else
					{	
						//no block can be moved 
						console.log("Can't move block");
						movePlayer = false;					
					}
				}
				//move the player
				if(movePlayer)
				{			
					sokobanBoard[characterPosition.x][characterPosition.y].Entities = null;
					sokobanBoard[tempX][tempY].Entities = Entities.Character;
					characterPosition = {x:tempX,y:tempY};
					//print the sokobanBoard after the move
					printSokoban();			
				}
							
			}	
		};

	}
	
})();



