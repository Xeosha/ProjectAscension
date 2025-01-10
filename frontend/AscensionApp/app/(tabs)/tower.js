import {useState} from 'react';
import { View, Text, StyleSheet } from "react-native";
import useResponsiveScreen from "../../hooks/useResponsiveScreen"

export default function Lobby() {
  const { width, height, hp } = useResponsiveScreen();
  const [anime] = useState(hp(100));

  return (  
    <View style={styles.container}>
      <Text style={styles.title}>Лобби</Text>
      <Text>Башня с уровнями монстров...</Text>
      <Text>Ширина: {width}</Text>
      <Text>Высота: {height}</Text>
      <Text>Переменная: {anime}</Text>
    </View>
  );
}

const styles = StyleSheet.create({
  container: { flex: 1, justifyContent: "center", alignItems: "center" },
  title: { fontSize: 20, fontWeight: "bold" },
});
