import { View, Text, StyleSheet } from "react-native";

export default function Guild() {
  return (
    <View style={styles.container}>
      <Text style={styles.title}>Гильдия</Text>
      <Text>Группы игроков...</Text>
    </View>
  );
}

const styles = StyleSheet.create({
  container: { flex: 1, justifyContent: "center", alignItems: "center" },
  title: { fontSize: 20, fontWeight: "bold" },
});
