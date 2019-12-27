#pragma once
#include <vector>

class GraphAdjMatrix
{
 private:
    std::vector<std::vector<int>> _elements;
 public:
    explicit GraphAdjMatrix(int);
    explicit GraphAdjMatrix(std::vector<std::vector<int>>);

    void Print();
};

class GraphAdjList
{
 private:
    std::vector<std::vector<int>> _elements;
 public:
    explicit GraphAdjList(int);
    explicit GraphAdjList(std::vector<std::vector<int>>);

    void AddEdgeUndirected(int, int);
    void AddEdgeDirected(int, int);

    void Print();
    void DFS(int);
    void DFS();
    void TopSort();
    bool HaveCycle();
    void BFS(int);
    bool BFS(std::vector<int>*, std::vector<int>*, int, int);
    void ShortestParth(int, int);
};

