
open System.Net
open System

let load web =
    async {
        let request = WebRequest.Create( web |> Uri )
        use! response = request.AsyncGetResponse()
        use  stream = response.GetResponseStream()
        use  reader = new IO.StreamReader(stream)
        return reader.ReadToEnd()
    }

#time
load "http://www.google.com" |> Async.RunSynchronously
#time


