
let indices = [1;2;3;4;5;6]

let newIndices = seq {
    let currentCell = ref 0
    for a, b in indices do
        yield !currentCell, a
        yield a, b
        currentCell := b
    yield !currentCell, 100
}

newIndices;