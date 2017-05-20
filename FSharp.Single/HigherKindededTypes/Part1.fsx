open System

module A =
    type LineItem = {
        articleId: string
        units: int
        amount: float
    }

module B =
    type Decision<'a> = Decision of 'a
    type InProgress<'a> = { value : 'a; desicsion: Decision<'a> }
    type LineItemInProgress = {
        articleId: InProgress<string>
        uints: InProgress<int>
        amounts: InProgress<float>
    }

    type Finished<'a> = { value: 'a; initial: 'a; timestamp: DateTime}
    type LineItemFinished = {
        articleId: Finished<string>
        units: Finished<int>
        amount: Finished<float>
    }


