package GraphBootcamp;

import java.util.*;

public class Example {
    public static void main(String[] arguments) {
        List<MatchResult> mrs = new ArrayList<>();
        mrs.add(new MatchResult("a", "c"));
        mrs.add(new MatchResult("c", "d"));
        mrs.add(new MatchResult("d", "b"));

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

    /**
     * Build a dictionary where the key is a winning team and the value is a hash set of teams that
     * the key has beaten.
     */
    private static Map<String, Set<String>> buildGraph(List<MatchResult> matches) {
        Map<String, Set<String>> graph = new HashMap<>();
        for (MatchResult match : matches) {
            Set<String> edges = graph.get(match.winningTeam);
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