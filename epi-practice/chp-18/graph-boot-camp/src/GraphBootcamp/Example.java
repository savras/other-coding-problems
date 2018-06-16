package GraphBootcamp;

import java.util.*;

public class Example {
    public static void main(String[] arguments) {
        List<MatchResult> mrs = new ArrayList<>();
        mrs.add(new MatchResult("a", "b"));
        mrs.add(new MatchResult("a", "b"));
        mrs.add(new MatchResult("b", "a"));
        MatchResult mr = new MatchResult("a", "b");

        System.out.println(canTeamABeatTeamB(mrs, "a", "b"));
    }

    public static class MatchResult {
        public String winningTeam;
        public String losingTeam;

        public MatchResult(String winningTeam, String losingTeam) {
            this.winningTeam = winningTeam;
            this.losingTeam = losingTeam;
        }
    }

    public static boolean canTeamABeatTeamB(List<MatchResult> matches, String teamA, String teamB) {
        Set<String> visited = new HashSet<>();
        return isReachableDFS(buildGraph(matches), teamA, teamB, visited);
    }

    private static Map<String, Set<String>> buildGraph(List<MatchResult> matches) {
        Map<String, Set<String>> graph = new HashMap<>();
        Set<String> edges = new HashSet<>();
        for (MatchResult match : matches) {
            if (edges == null) {
                edges = new HashSet<>();
                graph.put(match.winningTeam, edges);
            }
            edges.add(match.losingTeam);
        }
        return graph;
    }

    public static boolean isReachableDFS(Map<String, Set<String>> graph, String curr, String dest, Set<String> visited) {
        if (curr.equals(dest)) {
            return true;
        } else if (visited.contains(curr) || graph.get(curr) == null) {
            return false;
        }

        visited.add(curr);
        for (String team : graph.get(curr)) {
            if (isReachableDFS(graph, team, dest, visited)) {
                return true;
            }
        }
        return false;
    }
}