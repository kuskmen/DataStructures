#include "Graph.hpp"

#include <iostream>
#include <queue>
#include <stack>
#include <functional>
#include <utility>

GraphAdjMatrix::GraphAdjMatrix(int size)
{
    _elements = std::vector<std::vector<int>>(size);

    for (size_t i = 0; i < size; i++)
        _elements[i] = std::vector<int>(size);
}

GraphAdjMatrix::GraphAdjMatrix(std::vector<std::vector<int>> matrix)
{
    _elements = std::move(matrix);
}

void GraphAdjMatrix::Print()
{
    for (int v = 0; v < _elements.size(); v++)
    {
        std::cout << v;
        for (size_t c = 0; c < _elements.size(); c++)
        {
            if (_elements[v][c] == 1)
                std::cout << "->" << c;
        }
        std::cout << std::endl;
    }
}

GraphAdjList::GraphAdjList(int size)
{
    _elements = std::vector<std::vector<int>>(size);

    for (int i = 0; i < size; i++)
        _elements[i] = std::vector<int>();
}

GraphAdjList::GraphAdjList(std::vector<std::vector<int>> vertices)
{
    _elements = std::move(vertices);
}

void GraphAdjList::Print()
{
    for (int v = 0; v < _elements.size(); ++v)
    {
        std::cout << v;
        for (auto x : _elements[v])
            std::cout << "->" << x;
        std::cout << std::endl;
    }
}

// Finds vertices reachable from given vertex
void GraphAdjList::DFS(int vertex)
{
    std::vector<bool> visited(_elements.size(), false);

    std::function<void(int, std::vector<std::vector<int>>)> recurse =
        [&recurse, &visited](int vertex, std::vector<std::vector<int>> vertices)
    {
        visited[vertex] = true;
        std::cout << vertex << " ";

        for (auto itr = vertices[vertex].begin();
                itr != vertices[vertex].end(); ++itr)
            if (!visited[*itr])
                recurse(*itr, vertices);
    };

    recurse(vertex, _elements);
}

void GraphAdjList::DFS()
{
    std::vector<bool> visited(_elements.size(), false);

    std::function<void(int, std::vector<std::vector<int>>)> recurse =
        [&recurse, &visited](int vertex, std::vector<std::vector<int>> vertices)
    {
        visited[vertex] = true;
        std::cout << vertex << " ";

        for (auto itr = vertices[vertex].begin();
                itr != vertices[vertex].end(); ++itr)
            if (!visited[*itr])
                recurse(*itr, vertices);
    };

    int num_connected_components = 0;
    for (int i = 0; i < _elements.size(); ++i)
    {
        if (visited[i] == false)
        {
            num_connected_components++;
            recurse(i, _elements);
        }
    }

    std::cout << "\nConnected components are: " << num_connected_components;
}

void GraphAdjList::TopSort()
{
    std::stack<int> sorted_vertices;
    std::vector<bool> visited(_elements.size(), false);

    std::function<void(int, std::vector<std::vector<int>>)> recurse =
        [&recurse, &visited, &sorted_vertices]
        (int vertex, std::vector<std::vector<int>> vertices)
    {
        visited[vertex] = true;

        for (auto itr = vertices[vertex].begin();
                itr != vertices[vertex].end(); ++itr)
            if (!visited[*itr])
                recurse(*itr, vertices);

        sorted_vertices.push(vertex);
    };

    for (int i = 0; i < _elements.size(); ++i)
        if (visited[i] == false)
            recurse(i, _elements);

    while (!sorted_vertices.empty())
    {
        std::cout << sorted_vertices.top() << " ";
        sorted_vertices.pop();
    }
}

// This functions doesnt make sense on undirected graphs
bool GraphAdjList::HaveCycle()
{
    std::vector<bool> visited(_elements.size(), false);
    bool cycle = false;

    std::function<void(int, std::vector<std::vector<int>>)> recurse =
        [&recurse, &visited, &cycle]
        (int vertex, std::vector<std::vector<int>> vertices)
    {
        visited[vertex] = true;

        for (auto itr = vertices[vertex].begin();
                itr != vertices[vertex].end(); ++itr)
            if (visited[*itr])
                cycle = true;
            else
                recurse(*itr, vertices);
    };

    for (int i = 0; i < _elements.size(); ++i)
    {
        if (cycle)
            return cycle;
        else if (!visited[i])
            recurse(i, _elements);
    }

    return cycle;
}

void GraphAdjList::ShortestParth(int start, int end)
{
    std::vector<int> pred(_elements.size()), dist(_elements.size());

    if (BFS(&pred, &dist, start, end))
    {
        std::vector<int> path;
        int crawl = end;
        path.push_back(crawl);
        while (pred[crawl] != -1) {
            path.push_back(pred[crawl]);
            crawl = pred[crawl];
        }

        std::cout << "Shortest path length is : " << dist[end] << std::endl;

        std::cout << "Path is: " << std::endl;
        for (int i = path.size() - 1; i >= 0; i--)
            std::cout << path[i] << " ";

        return;
    }

    std::cout << "No path between " << start << " and " << end;
}

bool GraphAdjList::BFS(
    std::vector<int>* pred, std::vector<int>* dist, int start, int end)
{
    std::vector<bool> visited(_elements.size(), false);
    std::queue<int> processing_vertices;

    (*pred)[start] = -1;
    visited[start] = true;
    processing_vertices.emplace(start);

    while (!processing_vertices.empty())
    {
        int vertex = processing_vertices.front();
        processing_vertices.pop();

        for (int i = 0; i < _elements[vertex].size(); ++i)
        {
            if (visited[_elements[vertex][i]] == false)
            {
                visited[_elements[vertex][i]] = true;
                (*pred)[_elements[vertex][i]] = vertex;
                (*dist)[_elements[vertex][i]] = (*dist)[vertex] + 1;

                processing_vertices.push(_elements[vertex][i]);

                if (_elements[vertex][i] == end)
                    return true;
            }
        }
    }

    return false;
}

void GraphAdjList::BFS(int vertex)
{
    std::queue<int> processing;
    std::vector<bool> visited(_elements.size(), false);
    visited[vertex] = true;
    std::cout << vertex << " ";

    processing.emplace(vertex);
    while (!processing.empty())
    {
        int v = processing.front();
        processing.pop();

        for (auto itr = _elements[v].begin(); itr != _elements[v].end(); ++itr)
        {
            if (!visited[*itr])
            {
                std::cout << *itr << " ";
                visited[*itr] = true;
                processing.emplace(*itr);
            }
        }
    }
}

void GraphAdjList::AddEdgeUndirected(int vertex_x, int vertex_y)
{
    _elements[vertex_x].emplace_back(vertex_y);
    _elements[vertex_y].emplace_back(vertex_x);
}

void GraphAdjList::AddEdgeDirected(int vertex_x, int vertex_y)
{
    _elements[vertex_x].emplace_back(vertex_y);
}
