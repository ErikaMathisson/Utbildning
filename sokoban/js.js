function drawMap(map) {
	var main = document.createElement("div");
	main.style.width = map.width * 32 + "px";
	for(var row = 0;row < map.height;row++) {
		var rowDiv = document.createElement("div");
		for(var cell = 0;cell < map.width;cell++) {
			var cellDiv = document.createElement("div");
			cellDiv.id = row + "-" + cell;
			if(map.mapGrid[row][cell][0] === "W") {
				cellDiv.className = Tiles.Wall;
			} else if(map.mapGrid[row][cell][0] === "G") {
				cellDiv.className = Tiles.Goal;
			} else {
				cellDiv.className = Tiles.Space;
			}
			if(map.mapGrid[row][cell][0] === "P") {
				player.positionX = row;
				player.positionY = cell;
				cellDiv.classList.add(Entities.Character);
			} else if (map.mapGrid[row][cell][0] === "B") {
				cellDiv.classList.add(Entities.Block);
				blocks.push({positionX: row, positionY: cell, isPlayer: false, type: Entities.Block});
			}
			
			cellDiv.style.float = "left"
			rowDiv.appendChild(cellDiv);
		}
		main.appendChild(rowDiv);
	}
	document.body.appendChild(main);
}

function move(entity, direction) {
	var x = entity.positionX;
	var y = entity.positionY;
	switch(direction) {
		case "left":
			y--;
			break;
		case "up":
			x--;
			break;
		case "right":
			y++;
			break;
		case "down":
			x++;
			break;
		default:
			return false;
	}
	
	var nPosition = document.getElementById(x + "-" + y);
	var oPosition = document.getElementById(entity.positionX + "-" + entity.positionY);
	
	if(nPosition.classList.contains(Tiles.Wall)) {
		console.log("Wall");
		return false;
	} else {
		if(nPosition.classList.contains(Entities.Block)) {
			console.log("block")
			var block = null;
			for(var i = 0;i < blocks.length;i++) {
				if(blocks[i].positionX === x && blocks[i].positionY === y) {
					block = blocks[i];
					break;
				}
			}
			if(block !== null) {
				// if(!block.isPlayer) {
					// return false;
				// }
				if(!move(block, direction)){
					return false;
				}
				console.log("check after second move")
			}
		}
	}
	
	nPosition.classList.add(entity.type);
	oPosition.classList.remove(entity.type);
	entity.positionX = x;
	entity.positionY = y;
}


function readKey() {
	console.log(event.keyCode);
	switch(event.keyCode) {
		case 37:
			move(player, "left");
			break;
		case 38:
			move(player, "up");
			break;
		case 39:
			move(player, "right");
			break;
		case 40:
			move(player, "down");
			break;
		default:
			break;
	}
}


var blocks = [];
var player = {
	positionX: 0,
	positionY: 0,
	isPlayer: true,
	type: Entities.Character
}
drawMap(tileMap01);
document.onkeyup = readKey;



