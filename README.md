# Creating-a-Hierarchy-model-with-DateTime-in-CSharp
If you create your database models with DateTime attribute you can convert it to hierarchy model like Year-Month-Contents. I used Linq queries to create this structure.

In Hierarchy.cs you can see the Model structre defined nested.

Tipically I take the list and pars it.
Create a new Hierarchy model.

	 Hierarchy hierarchy= new Hierarchy();

And we will travell the list each by each in 

	foreach (var item in articles)
            {...

First, we will get the dateTime value from item and check the year value. If hierarchy model does not contain a year object,
we wil create it,  

	 DateTime date = item.creationDate;
	 if(hierarchy.years.SingleOrDefault(x=>x.yearValue==date.Year)== null)
                {
                    hierarchy.years.Add(new YearTag()
                    {
                        yearValue = date.Year
                    });
                }
and take this year value 

	 YearTag yearTag = hierarchy.years.Single(x => x.yearValue == date.Year);
	 
until we arrive to the last nest we do this proccess. 
Then we just add our item.

	mountTag.articles.Add(item);
	

After this process we will have got our object like that

	Hierarchy={
		2015={
			1={
				item1,item2,item3
			},
			3={
				item4,item5
			}
			..
			.
		}
		2016={
			...
		},
		2017={
			...
		}
	}
	
	
