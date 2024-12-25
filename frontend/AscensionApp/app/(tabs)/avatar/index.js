import { View, Text, StyleSheet } from "react-native";

export default function Avatar() {
  return (
    <View style={styles.container}>
      <Text style={styles.title}>Аватар</Text>
      <Text>Персонаж 1: Информация...</Text>
      <Text>Персонаж 2: Информация...</Text>
    </View>
  );
}

const styles = StyleSheet.create({
  container: { flex: 1, justifyContent: "center", alignItems: "center" },
  title: { fontSize: 20, fontWeight: "bold" },
});
