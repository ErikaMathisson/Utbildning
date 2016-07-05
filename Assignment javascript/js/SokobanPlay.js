
function printGrid()
{	
	var currentTileMap = tileMap01;
	var width = currentTileMap.width;
	var height = currentTileMap.height;
//	var ar = tileMap.mapGrid;
//	var row1 = [];
	
	document.getElementById("width").innerHTML = "Width " + currentTileMap.width; 
	document.getElementById("height").innerHTML = "Height " + currentTileMap.height; 
		
	// outer loop applies to outer array
/*	for (var i=0, len=ar.length; i<len; i++) {
	// inner loop applies to sub-arrays
		for (var j=0, len2=ar[i].length; j<len2; j++) {
		// accesses each element of each sub-array in turn
		console.log( ar[i][j] ); 
	//	document.getElementById("mapGrid").innerHTML = ar[i][j];
	}
}
*/

	for(var row = 0; row <currentTileMap.length; row++){
		var tileRow = doctype.createElement("div");
		tileRow.classList.add("tile-row");
		for(var cell = 0; row <currentTileMap[row].length; cell++){
			div.id = row + "-" +cell;
			
			var tileClass = currentTileMap[row][cell];
			div.classList.add("title");
		}
		
		
		
		
		
		
	}

	
};

	
function move()
{
	document.onkeydown = function(e) {
	switch (e.keyCode) {
		case 37:
			document.getElementById("key").innerHTML = "left key";
			console.log(e);
			break;
		case 38:
		//	alert("up key");
		document.getElementById("key").innerHTML = "up key";
			console.log(e);
			break;
		case 39:
		//	alert("right key");
			document.getElementById("key").innerHTML = "right key";
			console.log(e);
			break;
		case 40:
		//	alert("down key");
			document.getElementById("key").innerHTML = "down key";
			console.log(e);
			break;
	}
}
};
		
		
		
		
		
		
function Draw(tileMap) {
    if (tileMap != null) {
        currentTileMap = tileMap;
        container.width = currentTileMap[0].length * 32;
    }
    while (container.lastChild) {
        container.removeChild(container.lastChild);
    }
    for (var row = 0; row < currentTileMap.length; row++) {
        var tileRow = document.createElement("div");
        tileRow.classList.add("tile-row");
        for (var cell = 0; cell < currentTileMap[row].length; cell++) {
            var div = document.createElement("div");
            div.id = row + "-" + cell;

            var tileClass = currentTileMap[row][cell];

            div.classList.add("tile");
            if (tileClass == 'W') { div.classList.add(Tiles.Wall); }
            else if (tileClass == ' ') { div.classList.add(Tiles.Space); }
            else if (tileClass == 'G') { div.classList.add(Tiles.Goal); }
            else if (tileClass == 'B') {
                div.classList.add(Tiles.Space);
                var block = {
                    block: initEntity(Entities.Block),
                    position: { x: cell, y: row }
                };
                blocks.push(block);
                div.appendChild(block.block);
            }
            else if (tileClass == 'D') { div.classList.add(Entities.BlockDone); }
            else if (tileClass == 'P') {
                div.classList.add(Tiles.Space);
                player.position.x == -1 ? player.position.x = cell : null;
                player.position.y == -1 ? player.position.y = row : null;
                div.appendChild(player.block);
            }
            else { tileClass = "" }

            tileRow.appendChild(div);
        }
        container.appendChild(tileRow);
    }
}

		