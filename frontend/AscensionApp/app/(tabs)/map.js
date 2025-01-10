
import { Text, View, StyleSheet} from "react-native";

import { Emitter } from 'react-native-particles';

export default function Map() {
  return (
    <Emitter
        numberOfParticles={50}
        emissionRate={5}
        interval={200}
        particleLife={1500}
        direction={-90}
        spread={360}
        fromPosition={{ x: 200, y: 200 }}
        infiniteLoop={true}
        autoStart={true}
      >
        <View
            style={[
              styles.particle,
              {
                left: 5,
                top: 5,
                width: 5,
                height: 5,
                backgroundColor: "#414214",
              },
            ]}
          />
      </Emitter>
  );
}


const styles = StyleSheet.create({
  particle: {
    position: 'absolute',
    borderRadius: 50, // Сделать круглыми частицами
    opacity: 0.7,
  },
});