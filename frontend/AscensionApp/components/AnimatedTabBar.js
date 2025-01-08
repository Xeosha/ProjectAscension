import React, { useEffect, useRef } from 'react';
import { StyleSheet, TouchableOpacity, View } from 'react-native';
import * as Animatable from 'react-native-animatable';
import { MaterialCommunityIcons } from '@expo/vector-icons';
import { COLORS, FONTS } from '../constants/constants';
import { 
  widthPercentageToDP as wp,
  heightPercentageToDP as hp 
} from 'react-native-responsive-screen';


const animate1 = { 
  0: { scale: .5, translateY: 5}, 
  0.92: { translateY: - hp('7%')/ 2 }, 
  1: { scale: 1.2, translateY: - hp('7%') / 3 } 
};

const animate2 = { 
  0: { scale: 1.2, translateY: - hp('7%') / 3}, 
  1: { scale: 1, translateY: 7 } 
};

const circle1 = { 
  0: { scale: 0 }, 
  0.8: { scale: 1.2 }, 
  1: { scale: 1 } 
};
  
const circle2 = {   
    0: { scale: 1 }, 
    1: { scale: 0 } 
  };

const TabButton = (props) => {
  const { item, onPress, accessibilityState } = props;
  const focused = accessibilityState.selected;
  const viewRef = useRef(null);
  const circleRef = useRef(null);
  const textRef = useRef(null);

  useEffect(() => {
    if (focused) {
      viewRef.current.animate(animate1);
      circleRef.current.animate(circle1);
      textRef.current.transitionTo({ scale: 1 });
    } else {
      viewRef.current.animate(animate2);
      circleRef.current.animate(circle2);
      textRef.current.transitionTo({ scale: 0 });
    }
  }, [focused]);

  return (
    <TouchableOpacity
      onPress={onPress}
      activeOpacity={1}
      style={styles.container}>
      <Animatable.View
        ref={viewRef}
        duration={1000}
        style={styles.container}>
        <View style={styles.btn}>
          <Animatable.View
            ref={circleRef}
            style={styles.circle} />
          <MaterialCommunityIcons 
            name={item.icon} 
            size={24} 
            color={focused ? COLORS.white : COLORS.primary} 
          />
        </View>
        <Animatable.Text
          ref={textRef}
          style={styles.text}>
          {item.label}
        </Animatable.Text>
      </Animatable.View>
    </TouchableOpacity>
  );
};

export function AnimatedTabBar({ tabs, Tabs }) {
  return (
    <Tabs
      screenOptions={{
        headerShown: false,
        tabBarStyle: styles.tabBar,
      }}
    >
      {tabs.map((item) => (
        <Tabs.Screen
          key={item.route}
          name={item.route}
          options={{
            tabBarShowLabel: false,
            tabBarButton: (props) => <TabButton {...props} item={item} />
          }}
        />
      ))}
    </Tabs>
  );
}
const styles = StyleSheet.create({
  container: {
    flex: 1,
    justifyContent: 'center',
    alignItems: 'center',
  },
  tabBar: {
    height: hp('8%'),
    position: 'absolute',
    bottom: hp('1%'),
    marginHorizontal: wp('36%') > 300 ? wp('36%') : 15,
    borderRadius: 32,
    backgroundColor: COLORS.surface,
    shadowColor: COLORS.black,
    shadowOffset: {
      width: 2,
      height: 4,
    },
    shadowOpacity: 0.25,
    shadowRadius: 3.84,
    elevation: 5,
  },
  btn: {
    width: hp('5%'),
    height: hp('5%'), 
    borderRadius: hp('5%'),
    borderColor: COLORS.white,
    backgroundColor: COLORS.surface,
    justifyContent: 'center',
    alignItems: 'center',
  },
  circle: {
    ...StyleSheet.absoluteFillObject,
    alignItems: 'center',
    justifyContent: 'center',
    backgroundColor: COLORS.primary,
    borderRadius: hp('5%'),
  },
  text: {
    paddingTop: wp('0.35'),
    fontSize: hp('1.25'),
    textAlign: 'center',
    color: COLORS.white,
    fontWeight: '500',
    fontFamily: FONTS.regular,
  }
});

