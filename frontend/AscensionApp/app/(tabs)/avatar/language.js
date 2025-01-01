import { View, Text } from 'react-native';

export default function Language() {
  return (
    <View style={{ flex: 1, justifyContent: 'center', alignItems: 'center' }}>
      <Text>Настройки языка</Text>
    </View>
  );
}

/*
const styles = StyleSheet.create({
  container: {
    flex: 1,
    justifyContent: 'center',
    alignItems: 'center',
    height: SIZES.tabBarHeight,
  },
  tabBar: {
    height: SIZES.tabBarHeight,
    position: 'absolute',
    margin: SIZES.tabBarMargin,
    borderRadius: SIZES.tabBarBorderRadius,
    backgroundColor: COLORS.background,
    shadowColor: COLORS.black,
    shadowOffset: SIZES.shadowOffset,
    shadowOpacity: SIZES.shadowOpacity,
    shadowRadius: SIZES.shadowRadius,
    elevation: SIZES.elevation,
  },
  btn: {
    width: SIZES.buttonSize,
    height: SIZES.buttonSize,
    borderRadius: SIZES.buttonBorderRadius,
    borderWidth: SIZES.buttonBorderWidth,
    borderColor: COLORS.white,
    backgroundColor: COLORS.background,
    justifyContent: 'center',
    alignItems: 'center'
  },
  circle: {
    ...StyleSheet.absoluteFillObject,
    alignItems: 'center',
    justifyContent: 'center',
    backgroundColor: COLORS.primary,
    borderRadius: SIZES.buttonBorderRadius,
  },
  text: {
    fontSize: SIZES.fontSize,
    textAlign: 'center',
    color: COLORS.text,
    fontWeight: '500'
  }
});
*/