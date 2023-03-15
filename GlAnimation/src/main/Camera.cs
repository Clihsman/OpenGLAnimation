using lwjgl.vector;
using utils;
using OpenTK;
using System;
using OpenTK.Input;
using scene;
using App;

namespace main{

/**
 * Represents the in-game camera. This class is in charge of keeping the
 * projection-view-matrix updated. It allows the user to alter the pitch and yaw
 * with the left mouse button.
 * 
 * @author Karl
 *
 */
public class Camera : ICamera {

	private static float PITCH_SENSITIVITY = 0.3f;
	private static float YAW_SENSITIVITY = 0.3f;
	private static float MAX_PITCH = 90;

	private static float FOV = 70;
	private static float NEAR_PLANE = 0.2f;
	private static float FAR_PLANE = 400;

	private static float Y_OFFSET = 5;

	private Matrix4f projectionMatrix;
	private Matrix4f viewMatrix = new Matrix4f();

	private Vector3f position = new Vector3f(0, 0, 0);

	private float yaw = 0;
	private SmoothFloat pitch = new SmoothFloat(10, 10);
	private SmoothFloat angleAroundPlayer = new SmoothFloat(0, 10);
	private SmoothFloat distanceFromPlayer = new SmoothFloat(10, 5);

	public Camera() {
		this.projectionMatrix = createProjectionMatrix();
	}


	public void move() {
		calculatePitch();
		calculateAngleAroundPlayer();
		float horizontalDistance = calculateHorizontalDistance();
		float verticalDistance = calculateVerticalDistance();
		calculateCameraPosition(horizontalDistance, verticalDistance);
		this.yaw = 360 - angleAroundPlayer.get();
		yaw %= 360;
		updateViewMatrix();
	}
			
	public Matrix4f getViewMatrix() {
		return viewMatrix;
	}
			
	public Matrix4f getProjectionMatrix() {
		return projectionMatrix;
	}
			
	public Matrix4f getProjectionViewMatrix() {
		return Matrix4f.mul(projectionMatrix, viewMatrix, null);
	}

	private void updateViewMatrix() {
		viewMatrix.setIdentity();
		Matrix4f.rotate((float) MathHelper.DegreesToRadians(pitch.get()), new Vector3f(1, 0, 0), viewMatrix, viewMatrix);
			Matrix4f.rotate((float) MathHelper.DegreesToRadians(yaw), new Vector3f(0, 1, 0), viewMatrix, viewMatrix);
		Vector3f negativeCameraPos = new Vector3f(-position.x, -position.y, -position.z);
		Matrix4f.translate(negativeCameraPos, viewMatrix, viewMatrix);
	}

	private static Matrix4f createProjectionMatrix() {
		Matrix4f projectionMatrix = new Matrix4f();
		float aspectRatio = (float) Display.getWidth() / (float) Display.getHeight();
			float y_scale = (float) ((1f / Math.Tan(MathHelper.DegreesToRadians(FOV / 2f))));
		float x_scale = y_scale / aspectRatio;
		float frustum_length = FAR_PLANE - NEAR_PLANE;

		projectionMatrix.m00 = x_scale;
		projectionMatrix.m11 = y_scale;
		projectionMatrix.m22 = -((FAR_PLANE + NEAR_PLANE) / frustum_length);
		projectionMatrix.m23 = -1;
		projectionMatrix.m32 = -((2 * NEAR_PLANE * FAR_PLANE) / frustum_length);
		projectionMatrix.m33 = 0;
		return projectionMatrix;
	}

	private void calculateCameraPosition(float horizDistance, float verticDistance) {
		float theta = angleAroundPlayer.get();
			position.x = (float) (horizDistance * Math.Sin(MathHelper.DegreesToRadians(theta)));
		position.y = verticDistance + Y_OFFSET;
			position.z = (float) (horizDistance * Math.Cos(MathHelper.DegreesToRadians(theta)));
	}

	/**
	 * @return The horizontal distance of the camera from the origin.
	 */
	private float calculateHorizontalDistance() {
			return (float) (distanceFromPlayer.get() * Math.Cos(MathHelper.DegreesToRadians(pitch.get())));
	}

	/**
	 * @return The height of the camera from the aim point.
	 */
	private float calculateVerticalDistance() {
			return (float) (distanceFromPlayer.get() * Math.Sin(MathHelper.DegreesToRadians(pitch.get())));
	}

	/**
	 * Calculate the pitch and change the pitch if the user is moving the mouse
	 * up or down with the LMB pressed.
	 */
	private void calculatePitch() {
			if (Mouse.GetState().IsButtonDown(0)) {
				float pitchChange = AnimationApp.dy * PITCH_SENSITIVITY;
			pitch.increaseTarget(-pitchChange);
			clampPitch();
		}
			pitch.update(AnimationApp.time);
	}

	/**
	 * Calculate the angle of the camera around the player (when looking down at
	 * the camera from above). Basically the yaw. Changes the yaw when the user
	 * moves the mouse horizontally with the LMB down.
	 */
	private void calculateAngleAroundPlayer() {
			if (Mouse.GetState().IsButtonDown(0)) {
				float angleChange = AnimationApp.dx * YAW_SENSITIVITY;
			angleAroundPlayer.increaseTarget(-angleChange);
		}
			angleAroundPlayer.update(AnimationApp.time);
	}

	/**
	 * Ensures the camera's pitch isn't too high or too low.
	 */
	private void clampPitch() {
		if (pitch.getTarget() < 0) {
			pitch.setTarget(0);
		} else if (pitch.getTarget() > MAX_PITCH) {
			pitch.setTarget(MAX_PITCH);
		}
	}

	}}
