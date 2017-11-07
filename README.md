SOBE

CREATE TABLE Disciplina
    ID INT NOT NULL,
    Nome Varchar(40),
    PRIMARY KEY (ID);

CREATE TABLE Aluno
    ID INT NOT NULL,
    Nome Varchar(40),
    Email Varchar(40),
    PRIMARY KEY (ID);

CREATE TABLE Notas
    ID INT NOT NULL,
    Disciplina_ID INT,
    Aluno_ID INT,
    Nota INT,
    Frequencia INT,
    FOREIGN KEY (Disciplina_ID)
        REFERENCES Disciplina(ID),
    FOREIGN KEY (Aluno_ID)
        REFERENCES Aluno(ID)




import collections, re
texts = ['John likes to watch movies. Mary likes too.', 'John also likes to watch football games.']
bagsofwords = [ collections.Counter(re.findall(r'\w+', txt)) for txt in texts]
bagsofwords[0]
bagsofwords[1]
sumbags = sum(bagsofwords, collections.Counter())
sumbags



>>> from sklearn.cluster import KMeans
>>> import numpy as np
>>> X = np.array([[1, 2], [1, 4], [1, 0],
...               [4, 2], [4, 4], [4, 0]])
>>> kmeans = KMeans(n_clusters=2, random_state=0).fit(X)
>>> kmeans.labels_
array([0, 0, 0, 1, 1, 1], dtype=int32)
>>> kmeans.predict([[0, 0], [4, 4]])
array([0, 1], dtype=int32)
>>> kmeans.cluster_centers_
array([[ 1.,  2.],
       [ 4.,  2.]])
       
       http://scikit-learn.org/stable/modules/generated/sklearn.cluster.KMeans.html
       
       
       
       
       
import numpy as np
from sklearn.naive_bayes import GaussianNB


x = np.array([])


for i in range(1, train):
    with open('data.txt', 'r') as myfile:
        data_I=myfile.read().replace('\n', '')
        x = [d]

for 

X = np.array([[-1, -1], [-2, -1], [-3, -2], [1, 1], [2, 1], [3, 2]])
Y = np.array([1, 1, 1, 2, 2, 2])

clf = GaussianNB()
clf.fit(X, Y)
print(clf.predict([[-0.8, -1]]))
clf_pf = GaussianNB()
clf_pf.partial_fit(X, Y, np.unique(Y))
print(clf_pf.predict([[-0.8, -1]]))







• The “sweet spot” for an OKR grade is 60% – 70%; if someone consistently fully attains their objectives, their OKRs aren’t ambitious enough and they need to think bigger
• OKRs are not synonymous with employee evaluations
• OKRs are not a shared to-do list


• Where do I want to go? This answer provides the objective.
• How will I pace myself to see if I am getting there? • This answer provides the milestones, or key results.


• Google often sets goals that are just beyond the threshold of what seems possible, sometimes referred to as “stretch goals”. 


- Tips for introducing OKRs:

• What are OKRs? Cover the basics of what OKRs are and how they work.
• Why use OKRs? Review of how the organization currently approaches setting goals, and any limits or issues with that approach.
• How OKRs work? Explain the timeline, what is expected of each person, what the major milestones are, and how people will be accountable.
• Still skeptical about OKRs? Leave time for questions, with a particular emphasis on drawing out any skepticism.
• Alignment. Once the organization knows what it’s focused on and how it will measure success, it can become easier for individuals to connect their projects with the organizational objectives.

• Discipline & prioritization. It can be hard for any one team in a company to say no to a good idea, a worthwhile project, or a needed improvement. Once everyone agrees what the most important objectives are, it can be easier to say no to the less important ideas. Saying no isn’t a political or emotional debate, it becomes a rational response to a commitment that the entire organization has already made.

• Communication. OKRs should be public within an organization so that every employee knows the organizational objectives and metrics for success. In an interview, Dick Costolo, former Googler and former CEO of Twitter, was asked “What did you learn from Google that you applied to Twitter?” and shared:


- Tips for setting objectives:

• Pick just three to five objectives - more can lead to over-extended teams and a diffusion of effort.
• Avoid expressions that don’t push for new achievements, e.g., “keep hiring,” “maintain market position,” “continue doing X.”
• Use expressions that convey endpoints and states, e.g., “climb the mountain,” “eat 5 pies,” “ship feature Y.”
• Use tangible, objective, and unambiguous terms. It should be obvious to an observer whether or not an objective has been achieved. Research shows more specific goals can result in higher performance and goal attainment.


- Tips for developing key results:

• Determine around three key results per objective.
• Key results express measurable milestones which, if achieved, will directly advance the objective.
• Key results should describe outcomes, not activities. If the KRs include words like “consult,” “help,” “analyze,” “participate,” they’re describing activities. Instead, describe the impact of these activities, e.g., “publish customer service satisfaction levels by March 7th” rather than “assess customer service satisfaction.”
• Measurable milestones should include evidence of completion and this evidence should be available, credible, and easily discoverable.



• Miscommunicating stretch goal OKRs - Setting stretch goals requires careful communication within the teams delivering the objectives as well as other teams that depend on the work being delivered as part of the stretch goal OKR. If your project depends on another team’s objectives make sure you understand their goal-setting philosophy. If they are using stretch goals you should expect them to deliver on about 70% of their stated OKRs.

• Business-as-usual OKRs - OKRs are often written based on what the team believes it can achieve without changing anything they’re currently doing, as opposed to what the team or its customers really want. To test this, stack rank the team’s current work as well as newly requested projects in terms of value versus effort required. If the OKRs contain anything other than top efforts, then they are just business-as-usual OKRs. Drop low-priority efforts and reassign resources to the top OKRs. There are some objectives that will stay the same quarter after quarter, like “Ensure customer satisfaction is over XX%,” and this is ok if that objective is always a high priority. But the key results should evolve to push the team to continue to innovate and become more efficient.

• Sandbagging - Teams who can meet all of their OKRs without needing all of their team’s bandwidth may either be hoarding resources, not pushing their teams, or both.

• Low-value objectives - OKRs should promise clear business value - otherwise, there’s no reason to expend resources doing them. “Low-value objectives,” even if fully achieved, won’t make much of a difference to the organization. Ask, could the OKR get a 1.0 under reasonable circumstances without providing direct organizational benefit? If so, reword the OKR to focus on the tangible benefit.

• Insufficient key results for objectives - If the key results for a given objective don’t represent all that is needed to fully achieve that objective, an unexpected miss on that OKR can happen. That can cause delays of both the discovery of the resource requirements as well as the discovery that the objective will not be completed on schedule.
