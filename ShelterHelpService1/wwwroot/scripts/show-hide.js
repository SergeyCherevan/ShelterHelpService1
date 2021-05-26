let opasity = 300;

function HideAndBlock(e, op = opasity) {

	Unvisible(e);

	setTimeout(Block, op, e);
}

function UnblockAndShow(e, op = opasity) {

	Unvisible(e);

	setTimeout(Show, op, e);
}





function Show(e) {

	e.classList.remove('unvisible');
	e.classList.add('visible');
}

function Unvisible(e) {

	e.classList.remove('visible');
	e.classList.add('unvisible');
}

function Block(e) {

	e.classList.remove('visible', 'unvisible');
}