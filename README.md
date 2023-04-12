# Open AI Chatbot with C#
Create your own Open AI Chatbot in C# by consuming Open AI API

-----

## Step 1 - Create OPEN AI Account

- Create OPEN AI Account by visiting https://platform.openai.com/overview
- Create API Key at https://platform.openai.com/account/api-keys
- Generate your API Key

![image](https://user-images.githubusercontent.com/30829678/231580249-505ec23c-308f-4d34-b868-e5153996d262.png)


-----

## Step 2 - Consume Open AI API into your API Project

- Create VS.Net API Project
- Install Nuget Package `OpenAI`

![image](https://user-images.githubusercontent.com/30829678/231581016-70f2c57e-e7b6-480c-bd4b-e56853aa474f.png)

**Type in code to consume Open AI Api**

```csharp
using Microsoft.AspNetCore.Mvc;
using OpenAI_API.Completions;
using OpenAI_API;
using System.Text;

public class MyBotController : ControllerBase
{
    //Only demo purpose - I have use key inline.
    //Dont put the key in your code.
    string openAIKey = "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";

    [HttpGet]
    [Route("search")]
    public async Task<IActionResult> Search(string query)
    {   
        var openai = new OpenAIAPI(openAIKey);

        //Create Request
        CompletionRequest completionRequest = new CompletionRequest();            
        completionRequest.Prompt = query;
        completionRequest.Model = OpenAI_API.Models.Model.DavinciText;

        //Call API
        var completions = await openai.Completions.CreateCompletionAsync(completionRequest);

        //Build Output
        var sbOutput = new StringBuilder();
        foreach (var completion in completions.Completions)
        {
            sbOutput.Append(completion.Text);
        }
        return Ok(sbOutput.ToString());
    }
}
```

---------

## Testing

## Test 1 - 

**Question** - "Plan me 5 days vacation in dallas"

**Response** - 
Day One:
1. Visit the Dallas Museum of Art.

![image](https://user-images.githubusercontent.com/30829678/231584406-a644937e-eea5-4531-be36-d85167f8101a.png)

![image](https://user-images.githubusercontent.com/30829678/231586711-fb470919-49c4-4348-9ffe-4be8469c92ed.png)

Similarly you can keep asking question and you will keep getting answers.  You can create a react app on top of this to build and integrate this api.

---------

## Note:  You can play around with different request and response object parameter to best suits your needs.

**Request Object**
![image](https://user-images.githubusercontent.com/30829678/231583626-58d85323-c217-4351-a553-06bae5386946.png)

**Response Object**
![image](https://user-images.githubusercontent.com/30829678/231583951-f282d51e-2424-4ef8-a78d-b320cc610cd4.png)
