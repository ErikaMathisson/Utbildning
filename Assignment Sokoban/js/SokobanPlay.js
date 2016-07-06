//building the new sokobanBoard
var sokobanBoard = buildSokobanBoard();
//position for the character
var characterPosition = {x: 0, y : 0};

//function for building the sokobanboard and add the different tiles and enteties
function buildSokobanBoard()
{
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
			//	console.log("space");				
			}
			else if(sokobanCell == 'W')
			{
				cell.Tiles = Tiles.Wall;
			//	console.log("wall");
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
				
		//		characterPosition = {i,j};
	
				
				
				
		//		console.log("i? " + i);
		//		characterPosition.x =characterPosition.valueOf(i);
		//		console.log(" x : "+ characterPosition.x);
				
				
			/*	console.log("i? " + i);
				characterPosition.[0] = i;
				console.log(" x : "+ characterPosition.x);
				
				characterPosition.y = j;
				console.log(" y : "+ characterPosition.y);
				*/
			}
			
			board[i][j] = cell;			
		}		
	}
	
//	var x = characterPosition.x;
//	console.log(" x??? " +x);
	
	return board;	
}

//print the sokobanboard
function printSokoban()
{
	var container = document.getElementById("soko");
	
	
	for(var i = 0; i <sokobanBoard.length; i++)
	{
		container += "<tr>"
		
		
		
		for(var j = 0; j < sokobanBoard[i].length; j++)
		{
			
			var cell = sokobanBoard[i][j];
			console.log("cell: " +cell.Tiles);
			var style;
			
			if(cell.Tiles == Tiles.Space)
			{
				style ="space";				
			}
			else if(cell.Tiles == Tiles.Wall)
			{
				style ="wall";	
			}
			else if(cell.Tiles == Tiles.Goal)
			{
				style ="goal";	
			}
			else if(cell.Entities == Entities.Block)
			{
				style ="block";	
			}
			else if(cell.Entities == Entities.Character)
			{
				style ="character";	
			}
			
			container += "<td class='" + style + ">";
			console.log("cont "+container);
			container += "</td>";
			
		}
		
		container += "</tr>"
		
		container.innerHTML = container;
		
		
	}
	
	// document.body.appendChild
	
	
/*	
	
	
	
	var tblBoard = document.getElementById('tblBoard');
	var strHTML = ''; 
//	console.log("rad 195");
	for (var i=0; i<gBoard.length; i++) 
	{
		strHTML += "<tr>";
// console.log("rad 198");
//		for (var j=0; j<gBoard[0].length; j++) {

		for (var j=0; j<gBoard[i].length; j++) 
		{
		
//		console.log("rad 203");
			var currCell = gBoard[i][j];
//			console.log(currCell);
//			console.log(currCell.Tiles);
			
			var cellClass;
			
			
			
			
			if (currCell.Tiles == Tiles.Space) 
			{
				cellClass = "space";	
			//	console.log("space");
				
			} 
			else if (currCell.Tiles == Tiles.Wall) 
			{
				cellClass = "wall";
			//	console.log("wall");
		
			} 
			else if (currCell.Tiles == Tiles.Goal) 
			{
				cellClass = "target";
			//	console.log("goal");
			}
			else if(currCell.Entities == Entities.Character)
			{
				cellClass = "character";
			//	console.log("character");	
				
				gGamerPos = {i,j};
			//	console.log(gGamerPos);
				
			
			}
			else if(currCell.Entities == Entities.Block)
			{
				cellClass = "block";
			//	console.log("block");				
			}
			
			strHTML += "<td class='cell " + cellClass + "'  onclick='handleClick("+i+","+j+")' >";

			
			
			/*
			
			if (currCell.gameElement == GAMER) {
				strHTML += "<img src='img/Character.gif'>";
			} else if (currCell.gameElement == BOX) {
					strHTML += "<img src='img/Block.gif'>";
			}
			
			*/
			
			
			
			
			
			
			/*
			if (currCell.type == FLOOR) {
				cellClass = "floor";	
				
			} else if (currCell.type == WALL) {
				cellClass = "wall";
			
			} else if (currCell.type == TARGET) {
				cellClass = "target";
			}
			strHTML += "<td class='cell " + cellClass + "'  onclick='handleClick("+i+","+j+")' >";

			if (currCell.gameElement == GAMER) {
				strHTML += "<img src='img/Character.gif'>";
			} else if (currCell.gameElement == BOX) {
					strHTML += "<img src='img/Block.gif'>";
			}
			
			
			*/
			
			
			
	/*		
			strHTML += "</td>";
		}
		strHTML += "</tr>";
	}

	tblBoard.innerHTML = strHTML;
	
	
	
	*/
	
	
	
	
}


