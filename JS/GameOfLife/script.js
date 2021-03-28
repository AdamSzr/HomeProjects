let grid = []
let width = 10
let height = 10
let refreshTime = 500


const canvas = document.getElementById(`board`)

const inputSizeBoard = document.getElementById(`gameSize`)
inputSizeBoard.addEventListener(`change`, () => {
    const size = inputSizeBoard.value.split(`x`)
    changeBoradSize(size[0], size[1])
})


const inputFrames = document.getElementById(`generation`)
inputFrames.addEventListener(`change`, () => {
    let refreshTime = 1000 / inputFrames.value
    restartTimer(refreshTime)
})

/**
 * @type {Canvas}
 */
const ctx = canvas.getContext(`2d`)

let puzzleW = null
let puzzleH = null


init()

let timerHandler = setInterval(() => generation(), 500)

function changeBoradSize(h, w) {
    height = parseInt(h)
    width = parseInt(w)
    console.log(width, height)
    init()
}



function restartTimer(newTime) {
    window.clearInterval(timerHandler)
    timerHandler = setInterval(() => generation(), newTime)
}

function init() {
    puzzleW = canvas.width / width
    puzzleH = canvas.height / height

    grid = create2dArray(width, height)
    //init3Dots()
    fillArray(() => Math.round(Math.random()))
    draw()
}

function generation() {

    let nextframe = create2dArray(width, height)

    for (let i = 0; i < grid.length; i++) {
        for (let j = 0; j < grid[i].length; j++) {
            let neig = countNeighbors(i, j)
            let acctualState = grid[i][j]


            if (acctualState == 0 && neig == 3)
                nextframe[i][j] = 1
            else if (acctualState == 1 && (neig < 2 || neig > 3))
                nextframe[i][j] = 0
            else
                nextframe[i][j] = acctualState
        }
    }

    grid = nextframe
    draw()
}

function init3Dots() {
    const middleH = Math.floor(height / 2)
    const middleW = Math.floor(width / 2)

    grid[middleH + 1][middleW] = 1
    grid[middleH][middleW] = 1
    grid[middleH - 1][middleW] = 1


}


function countNeighbors(h, w) {
    let sum = 0

    if (h - 1 >= 0 && w - 1 >= 0 && h - 1 < height && w - 1 < width)
        sum += grid[h - 1][w - 1]

    if (h - 1 >= 0 && w >= 0 && h - 1 < height && w < width)
        sum += grid[h - 1][w]

    if (h - 1 >= 0 && w + 1 >= 0 && h - 1 < height && w + 1 < width)
        sum += grid[h - 1][w + 1]

    if (h >= 0 && w - 1 >= 0 && h < height && w - 1 < width)
        sum += grid[h][w - 1]

    if (h >= 0 && w + 1 >= 0 && h < height && w + 1 < width)
        sum += grid[h][w + 1]

    if (h + 1 >= 0 && w - 1 >= 0 && h + 1 < height && w - 1 < width)
        sum += grid[h + 1][w - 1]

    if (h + 1 >= 0 && w >= 0 && h + 1 < height && w < width)
        sum += grid[h + 1][w]

    if (h + 1 >= 0 && w + 1 >= 0 && h + 1 < height && w + 1 < width)
        sum += grid[h + 1][w + 1]

    return sum
}

function fillArray(valueGenerator) {
    for (let i = 0; i < grid.length; i++)
        for (let j = 0; j < grid[i].length; j++) {
            grid[i][j] = valueGenerator()
        }

}

function draw() {

    ctx.clearRect(0, 0, canvas.width, canvas.height)
    for (let i = 0; i < grid.length; i++)
        for (let j = 0; j < grid[i].length; j++) {
            const posx = j * puzzleW
            const posy = i * puzzleH

            if (grid[i][j] == 1) {
                ctx.fillStyle = `#707070`
                ctx.fillRect(posx, posy, puzzleW - 1, puzzleH - 1)
            }
        }
}


function create2dArray(rows, cols) {
    let array = []
    for (i = 0; i < rows; i++) {
        array[i] = new Array(cols).fill(0)
    }
    return array
}


