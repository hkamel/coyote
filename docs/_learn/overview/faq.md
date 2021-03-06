---
layout: reference
title: Frequently asked questions
section: learn
permalink: /learn/overview/faq
---

## Frequently asked questions

<br/>


#### Seems magical, how does Coyote really work?

I'm glad you asked. See [how does it work](../overview/how).
<br/><br/>

#### Will using Coyote affect the total budget for a software development project? 

It will have minimal impact initially, as developers ramp up on Coyote concepts. In the long run,
our experience with Azure teams suggests that it will help reduce the total budget. Coyote is
designed to add agility so that the development and testing processes move at a faster pace.
<br/><br/>

#### What type of projects will benefit most from using Coyote? 

Projects that have to deal with concurrency/asynchrony or other non-deterministic issues (such as
timers, failures and re-orderings).
<br/><br/>

#### Will Coyote slow down my production code?

No, Coyote is very lightweight.
<br/><br/>

#### How much time will developers need to learn Coyote? 

We have been working hard towards making Coyote accessible to all developers, however, we cannot
give a conclusive answer yet. We think that it won't take long. A junior engineer that recently
joined an Azure team using Coyote said: "_being a new developer to the team, one of the first few
things I worked on was Coyote, it was really quick to onboard, writing actual code is simple and
straightforward_". Tell us about your experience!
<br/><br/>

#### At what stage of the development lifecycle is it best to start using Coyote? 

Ideally at the very beginning, since you need to design and build using Coyote APIs. It is better to
do testing while developing, not after you are ready to ship :)
<br/><br/>

#### How much additional effort is needed to test an existing system with Coyote? 

Depends on what programming model and concurrency APIs you used for developing your existing system
because, for Coyote testing to work, it needs to understand the
[non-determinism](../core/non-determinism) in your system. In some cases, this may be as simple as
replacing the `System.Threading.Tasks.Task` type with
[`Microsoft.Coyote.Tasks.Task`](../programming-models/async/overview). In other cases, you would
also have to model additional non-determinism, such as timers and external services. In general, we
recommend using Coyote in early stages of development.
<br/><br/>

#### How is Coyote being maintained and what level of support can we expect? 

Coyote is currently an Open Source project on GitHub under the MIT license. Microsoft continues to
invest in Coyote and accepts community contributions as well. Issues can be posted there and will be
resolved in a timely manner. 
<br/><br/>

#### How do Coyote actors compare against other actor implementations like [Orleans](https://dotnet.github.io/orleans/), [Reliable Actors](https://docs.microsoft.com/en-us/azure/service-fabric/service-fabric-reliable-actors-introduction), or [Dapr actors](https://github.com/dapr/docs/blob/master/concepts/actors/README.md)?

The design of actors in Coyote is not meant to be a replacement for any of these system. In fact,
far from it. All of the systems mentioned in the question offer an implementation of distributed
actors, along with a distributed runtime, storage APIs and so forth so that you have have actors
that talk over the wire. In contrast, Coyote has in-memory actors. Just like Coyote tasks, Coyote
actors are meant to be very lightweight programmatic constructs that can be put alongside any
distributed runtime capable of hosting a .NET application. For instance, it should be possible to
develop a Coyote application and host it on top of [Dapr](https://dapr.io/). We are aware of at
least one team in Azure that has done something similar with [Service Fabric](https://azure.microsoft.com/en-us/services/service-fabric/)'s Reliable Actors: each
Reliable Actor is just used as a wrapper around a Coyote
[StateMachine](../programming-models/actors/state-machines). In this case, Service Fabric takes care
of distribution, messaging and managing the actor's lifetime, whereas Coyote StateMachines encodes
all the business logic, which is also thoroughly vetted by the Coyote tester. It would be
interesting to see the community develop further ways in which these technologies can be used
together to get the best of each.
<br/><br/>

#### How is Coyote different from other similar systems out there?

One comparison point for Coyote would be other offerings that help build reliable systems. It would
be difficult to give an exhaustive answer here, but Coyote is quite unique in its combination of
powerful testing and very light run-time requirements (i.e., it requires the .NET framework only).
Other systems might require a buy-in to a particular distributed runtime or messaging system, or
might not help much in the way of testing custom business logic. You can adapt Coyote to work with
whatever platform you are using today.
<br/><br/>

#### Is Coyote only available with Azure? 

No, Coyote can run in any Windows or Linux machine, regardless if it is a local machine or a VM on
the cloud.
<br/><br/>

#### How many machines do we need to run a Coyote program? 

A Coyote program is hosted in a .NET process, so it can easily run on just one machine. You can also
create a distributed Coyote program by connecting multiple processes, each running Coyote. You are
free to use any distributed host platform as well as any messaging system that you want.
<br/><br/>

#### Can Coyote be used with any existing distributed host and communication platform?
Yes, Coyote does not constrain you. Coyote is built on top of the .NET Task Parallel Library, and on
its own only executes in-memory in the scope of a single .NET process. To build a distributed Coyote
program, you are free to use any distributed host and communication mechanism that you like. All you
need to do is host your .NET processes (that execute your Coyote code) using your favorite
distributed system/framework (such as [Kubernetes](https://kubernetes.io/) or [Azure Service
Fabric](https://azure.microsoft.com/en-us/services/service-fabric/)) and connect these processes
using your favorite communication/messaging mechanism (such as [gRPC](https://grpc.io/), [Apache
Kafka](https://kafka.apache.org/) or [Azure Service
Bus](https://azure.microsoft.com/en-us/services/service-bus/)). To help you, we have a [sample that
shows how Coyote can be used with Azure Service Bus](../tutorials/raft-azure).
<br/><br/>

#### Is it meaningful to use Coyote for a program that runs on a single machine only?

Sure, in fact most testing with Coyote is performed on a single machine. Many Coyote users today
build reliable cloud services, and Coyote itself is not service-specific. You can use it to build
and test any kind of asynchronous .NET program that needs to be reliable.
<br/><br/>


