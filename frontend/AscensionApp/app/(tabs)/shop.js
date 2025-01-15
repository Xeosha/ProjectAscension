import { View, Text, StyleSheet } from "react-native";

export default function Shop() {
  return (
    <View style={styles.container}>
      <Text style={styles.title}>Магазин</Text>
      <Text>Купить и продать предметы...</Text>
    </View>
  );
}

const styles = StyleSheet.create({
  container: { flex: 1, justifyContent: "center", alignItems: "center" },
  title: { fontSize: 20, fontWeight: "bold" },
});

