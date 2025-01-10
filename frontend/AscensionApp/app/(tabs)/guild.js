import React from "react";
import { View, Text, StyleSheet } from "react-native";
import { Emitter } from "react-native-particles";

export default function Guild() {
  return (
    <View style={styles.container}>
      <Text style={styles.title}>Гильдия</Text>
      <Text>Группы игроков...</Text>
      <Emitter
        numberOfParticles={200}
        emissionRate={1}
        interval={200}
        particleLife={4500}
        direction={50}
        spread={50}
        speed={4}
        gravity={15}
        fromPosition={() => ({ x: Math.random() * 2000, y: Math.random() * 1 })}
        infiniteLoop={true}
        style={styles.emitter}
      >
        <Text style={styles.snowflake}>❄️</Text>
      </Emitter>
    </View>
  );  
}

const styles = StyleSheet.create({
  container: { flex: 1, justifyContent: "center", alignItems: "center" },
  title: { fontSize: 20, fontWeight: "bold" },
  snowflake: { fontSize: 20, color: "white" },
  emitter: { position: "absolute", width: "100%", height: "100%" },
});
