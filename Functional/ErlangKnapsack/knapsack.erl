
% Copyright (c) 2017-2018 Daniil Belov and Jonas Nydegger
%
% Permission is hereby granted, free of charge, to any person obtaining a copy
% of this software and associated documentation files (the "Software"), to deal
% in the Software without restriction, including without limitation the rights
% to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
% copies of the Software, and to permit persons to whom the Software is
% furnished to do so, subject to the following conditions:
%
% The above copyright notice and this permission notice shall be included in all
% copies or substantial portions of the Software.
%
% THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
% IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
% FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
% AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
% LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
% OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
% SOFTWARE.

% Module identifier. Must be present in a file in order to be executed by the VM
-module(knapsack).
 
% All the functions and these argument count separated by / sign are listed here
-export([solve_and_print/0,
         print_result/1,
         calculate_solution/5]).

% private static final Integer MAXIMAL_KNAPSACK_CAPACITY = 750;
-define(MAXIMAL_KNAPSACK_CAPACITY, 750).
 
% Defining a collection of elements from the verified test data
% taken here https://people.sc.fsu.edu/~jburkardt/datasets/knapsack_01/knapsack_01.html, dataset P07
% Deque<Tuple<String,Integer,Integer>> ITEMS_TO_CHOOSE_FROM = new ArrayDeque<>(...);
% First Integer represents weight, the second - value
-define(ITEMS_TO_CHOOSE_FROM,
        [{"Burger",70,135},
         {"Pizza",73,139},
         {"Tea",77,149},
         {"Sandwich",80,150},
         {"Soup",82,156},
         {"Salad",87,163},
         {"Quorn mediterranean style",90,173},
         {"Saitan",94,184},
         {"Raclette",98,192},
         {"Chocolade",106,201},
         {"Ramen",110,210},
         {"Sushi",113,214},
         {"Bami Goreng",115,221},
         {"Cream soup",118,229},
         {"Potatoes",120,240}]).

% Upon matching with an empty result list
% Just return a special "ok" tuple
% Which means there are no more results 
% (or have never been any results)
print_result([]) -> ok;

% Upon matching with an non-empty result list
% print it recursively starting from the tail(using tail-recursion)
% for(Item item : SolutionItems){
%   System.out.println(item.ToString());
% }
print_result([H|T]) ->  io:format("~p~n", [H]), [H|print_result(T)].

%public class FinalKnapsackSolution 
%{
%   private Deque<Item> SolutionItems = new ArrayDeque<>(); 
%   private Integer TotalValue;
%   private Integer TotalValue;
%}
solve_and_print() ->

    % Executing calculate_solution function feeding it with predefined items and maximal capacity.
    % The third, fourth and fifth arguments are initialized as empty list and 0 accordingly as there 
    % is no solution yet present at the moment
    {SolutionItems, TotalValue, TotalWeight} = calculate_solution(
                                                                    ?ITEMS_TO_CHOOSE_FROM, 
                                                                    ?MAXIMAL_KNAPSACK_CAPACITY, 
                                                                    [], 
                                                                    0, 
                                                                    0
                                                                ),
    % Printing the final result
    io:format("Printing the solution knapsack contents:~n"), 
    print_result(SolutionItems),
    io:format("Total value of the solution: ~p~n", [TotalValue]), 
    io:format("Total weight of the solution: ~p~n", [TotalWeight]).
 
% Upon matching with an empty list (there are no more items in the problem or its part) 
% construct a tuple with a solution items collection and its value and weight
calculate_solution([], _TotalWeight, SelectedItemsCollection, AccumulatedValue, AccumulatedWeight) ->  {SelectedItemsCollection, AccumulatedValue, AccumulatedWeight};

% Upon matching with a non-empty list check whether this particular item 
% we are trying to put into knapsack fits at all.  
calculate_solution([{_Item, ItemWeight, _ItemValue} | T], TotalWeight, SelectedItemsCollection, AccumulatedValue, AccumulatedWeight) 
% If not (weight of a current item we are trying to add exceeds the weight of the knapsack), 
% pass the other elements (except for this one) of the list to recursion the tail and try to fit it in the solution
when ItemWeight > TotalWeight -> calculate_solution(T, TotalWeight, SelectedItemsCollection, AccumulatedValue, AccumulatedWeight);

% Because Erlang List ADT provides us only with access on its Head and Tail element,
% we need to determine which elements are more profitable to take
% Upon matching with a non-empty list count the possible solutions on the head and the tail 
% and return it to the next recursion level.
% Important : IF statement does not function as in Java or C#. It MUST have a return value, and in this case, 
% "true" means "else".
calculate_solution([{ItemName, ItemWeight, ItemValue} | T], TotalWeight, SelectedItemsCollection, AccumulatedValue, AccumulatedWeight) ->
    {_HeadItemAcc, HeadValueAcc, _HeadWeightAcc} = ResultWithHeadElement = calculate_solution(T, TotalWeight - ItemWeight, [ItemName | SelectedItemsCollection], AccumulatedValue + ItemValue, AccumulatedWeight + ItemWeight),
    {_TailItemAcc, TailValueAcc, _TailWeightAcc} = ResultWithTailElement = calculate_solution(T, TotalWeight, SelectedItemsCollection, AccumulatedValue, AccumulatedWeight),
    if HeadValueAcc > TailValueAcc -> ResultWithHeadElement; true -> ResultWithTailElement end.